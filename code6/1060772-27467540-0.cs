    public static class TextBoxExtensions
    {
        public static void CheckAppendText(this TextBoxBase textBox, string msg, bool waitUntilReturn = false)
        {
            Action append = () => textBox.AppendText(msg);
            if (textBox.CheckAccess())
            {
                append();
            }
            else if (waitUntilReturn)
            {
                textBox.Dispatcher.Invoke(append, null);
            }
            else
            {
                textBox.Dispatcher.BeginInvoke(append, null);
            }
        }
    }
