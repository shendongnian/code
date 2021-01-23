    using YourApp.Properties;
    using System;
    using System.Windows.Forms;
    
    namespace YourApp.Controls
    {
        public partial class TypeDelayTextBox : TextBox
        {
            public TypeDelayTextBox()
            {
                InitializeComponent();
    
                this.HandleCreated += (senderX, argsX) => { this.TextChanged += OnTextChanged; };
            }
    
            private void OnTextChanged(object sender, EventArgs args)
            {
                _timer.Enabled = true;
                _timer.Stop();
                _timer.Start();
            }
    
            private void _timer_Tick(object sender, EventArgs e)
            {
                _timer.Stop();
                Settings.Default.Save();
                OnTypingFinished();
            }
    
            public event EventHandler TypingFinished;
    
            protected virtual void OnTypingFinished()
            {
                TypingFinished?.Invoke(this, EventArgs.Empty);
            }
        }
    }
