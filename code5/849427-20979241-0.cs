    public partial class YourUserControl : UserControl
    {
        public String Text
        {
            get
            {
                return this.txtBox1.Text;
            }
            //write the setter property if you would like to set the text 
            //of the TextBox from your aspx page
            //set
            //{
            //    this.txtBox1.Text = value;
            //}
        }
        public delegate void ApplyTextClickedEventHandler(Object sender, EventArgs e);
        public event ApplyTextClickedEventHandler ApplyTextClicked;
        protected virtual void OnApplyTextClicked(EventArgs e)
        {
            //Checking if the event has been subscribed or not...
            if (ApplyTextClicked != null)
                ApplyTextClicked(this, e);
        }
        protected void yourUserControlButton_Click(Object sender, EventArgs e)
        {
            OnApplyTextClicked(EventArgs.Empty);
        }
    }
