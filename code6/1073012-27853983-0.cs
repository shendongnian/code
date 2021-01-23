    public class ButtonLogger
    {
        public static void AttachButtonLogging(Form form)
        {
            foreach (var field in form.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (field.GetValue(form) is Button)
                {
                    System.Windows.Forms.Button button = (Button)field.GetValue(form);
                    button.Click += LogButtonClick;
                }
            }
        }
        private static void LogButtonClick(object sender, EventArgs eventArgs)
        {
            Button button = sender as Button;
            WriteLog("Click: " + button.Parent.Name.ToString() + "." + button.Name.ToString() + " (\"" + button.Text + "\")");
        }
        private static void WriteLog(string message)
        {
            //...
        }
    }
