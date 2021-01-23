    public static class TextBoxExtensions
    {
        public static bool IsEmpty(this TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(null == textBox ? null : textBox.Text);
        }
    }
