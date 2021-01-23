    public class TextBoxConsoleContext : IConsoleContext
    {
        #region Nested types
        private class TextBoxConsole : IConsole
        {
            #region Fields
            private TextBoxConsoleContext parent;
            #endregion
            #region Constructors
            public TextBoxConsole(TextBoxConsoleContext parent)
            {
                if (parent == null)
                    throw new ArgumentNullException("parent");
                this.parent = parent;
            }
            #endregion
            
            #region IConsole implementation
            public ConsoleKeyInfo ReadKey()
            {
                var key = this.parent.m_Queue.Dequeue();
                this.WriteLine(key.KeyChar.ToString());
                return key;
            }
            public void WriteLine(string line)
            {
                Action writeLine = () =>
                    {
                        var textToAppend = String.Format("{0}{1}",
                            line,
                            Environment.NewLine);
                        this.parent.m_TextBox.AppendText(textToAppend);
                    };
                this.parent.m_TextBox.Invoke(writeLine);
            }
            #endregion
        }
        #endregion
        #region Fields
        private TextBox m_TextBox;
        private BlockingProducerConsumerQueue<ConsoleKeyInfo> m_Queue = new BlockingProducerConsumerQueue<ConsoleKeyInfo>();
        private Boolean m_Shift;
        private Boolean m_Alt;
        private Boolean m_Ctrl;
        private ConsoleKey m_KeyInfo;
        #endregion
        #region Constructors
        public TextBoxConsoleContext(TextBox textBox)
        {
            if (textBox == null)
                throw new ArgumentNullException("textBox");
            
            this.m_TextBox = textBox;
            this.m_TextBox.ReadOnly = true;
            // Event handler that will read key down data before key press
            this.m_TextBox.KeyDown += (obj, e) =>
                {
                    this.m_Shift = e.Modifiers.HasFlag(Keys.Shift);
                    this.m_Alt = e.Modifiers.HasFlag(Keys.Alt);
                    this.m_Ctrl = e.Modifiers.HasFlag(Keys.Control);
                    if (!Enum.TryParse<ConsoleKey>(e.KeyCode.ToString(), out this.m_KeyInfo))
                    {
                        this.m_KeyInfo = ConsoleKey.Escape;
                    }                   
                };
            this.m_TextBox.KeyPress += (obj, e) =>
                {
                    this.m_Queue.EnqueueIfRequired(new ConsoleKeyInfo(e.KeyChar, 
                        this.m_KeyInfo, 
                        this.m_Shift, 
                        this.m_Alt,
                        this.m_Ctrl));
                };
        }
        #endregion
        #region IConsoleContext implementation
        public void Run(Action<IConsole> main)
        {
            if (main == null)
                throw new ArgumentNullException("main");
            var console = new TextBoxConsole(this);
            Task.Run(() =>
                main(console));
        }
        #endregion
    }
