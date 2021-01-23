    public class CustomTextBox : TextBox
    {
        public override string Text
        {
            get { return base.Text.Trim(); }
            set { base.Text = value; }
        }
    }
