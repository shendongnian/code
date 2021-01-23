    public class CustomTextBox : TextBox
    {
        public string testText { get; set; }
        public CustomTextBox()
            : base()
        {
            if (string.IsNullOrEmpty(testText))
            {
                throw new ArgumentNullException();
            }
        }
    }
