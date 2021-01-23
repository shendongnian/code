    public class MyUserControl : UserControl
    {
        public string Caption
        {
            get { return this.textbox1.Text; }
            set { this.textbox1.Text = value; }
        }
    }
