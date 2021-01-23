    public class MyInputPrompt : InputPrompt
    {
        public TextBox MyInputBox
        {
            get { return this.InputBox; }
            set
            {
                if (value != this.InputBox)
                {
                    this.InputBox = value;
                }
            }
        }
    }
