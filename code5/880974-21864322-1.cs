    public class SomeTestClass
    {
        private string text;
        public string Text 
        { 
            get
            {
                return text;
            }
            set
            {
                CheckConstraints(value, "Text");
                text = value;
            }
        }
        private void CheckConstraints(string value, string param)
        {
            if (Regex.IsMatch(value, @"\d{6,}"))
            {
                throw new ArgumentException("Argument do not match the constraint", param);
            }
        }
    }
