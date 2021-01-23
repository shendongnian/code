    public class FormTest : Form
    {
        public FormTest() : base()
        {
            LimitedTextBox tb = new LimitedTextBox();
            this.Controls.Add(tb);
            tb.Text = "123456";
            tb.MaxLength = 8;
            tb.HasPreenteredText = true;
        }
    }
    public class LimitedTextBox : TextBox
    {
        private int preenteredTextLength = -1;
        private bool hasPreenteredText = false;
        public bool HasPreenteredText
        {
            get { return hasPreenteredText; }
            set
            {
                if (value == true)
                { preenteredTextLength = this.TextLength; }
                else
                { preenteredTextLength = -1; }
                hasPreenteredText = value;
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (this.TextLength <= preenteredTextLength && e.KeyChar == '\b')
            { e.Handled = true; } // Causes the KeyPress to be skipped as it was already 'handled'
            base.OnKeyPress(e);
        }
    }
