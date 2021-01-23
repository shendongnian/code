    internal class TextBoxTraceListener : TraceListener {
        static Form DebugWindow { get; set; }
        static TextBox DebugTextBox { get; set; }
        public TextBoxTraceListener() {
            if (DebugWindow == null) {
                DebugWindow = new Form();
                
                DebugTextBox = new TextBox();
                DebugTextBox.Multiline = true;
                DebugTextBox.Dock = DockStyle.Fill;
                DebugWindow.Controls.Add(DebugTextBox);
            }
            DebugWindow.Show();
        }
        public override void Write(string message) {
            DebugTextBox.Text += message;
        }
        public override void WriteLine(string message) {
            Write(message + Environment.NewLine);
        }
    }
