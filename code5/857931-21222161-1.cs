    public class CustomTextBox : TextBox
    {
        public string DefaultText { get; set; }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Text = DefaultText;
        }
    }
