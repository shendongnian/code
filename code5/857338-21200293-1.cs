    public static class TextBoxUtility
    { 
        public static bool HasText(this TextBox textBox)
        {
            return !string.IsNullOrEmpty(textBox.Text);
        }
    }
    ...
    if(textBox1.HasText())
    {
    }
