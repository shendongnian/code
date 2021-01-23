    public class TrimmedTextBox : TextBox
    {
        public new string Text
        {
            get
            {
                 var t = (string) GetValue(TextProperty);
                return t != null ? t.Trim() : string.Empty;
            }
        }
    }
