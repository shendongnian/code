    public static class Extensions
    {
        public static void AddOnce(this TextBox textbox, string text)
        {
            string originalText = textbox.Tag + "";
            if (originalText.Length == 0)
            {
                originalText = textbox.Text;
                textbox.Tag = originalText;
            }
            textbox.Text = originalText + text;
        }
    }
