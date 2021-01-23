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
        public delegate void TextAppliedEventHandler(Object sender, EventArgs e);
        public event TextAppliedEventHandler TextApplied;
        protected virtual void OnTextApplied(EventArgs e)
        {
            //Taking a local copy of the event, 
            //as events can be subscribed/unsubscribed asynchronously.
            //If that happens after the below null check then 
            //NullReferenceException will be thrown
            TextAppliedEventHandler handler = TextApplied;
            //Checking if the event has been subscribed or not...
            if (handler != null)
                handler(this, e);
        }
        protected void yourUserControlButton_Click(Object sender, EventArgs e)
        {
            OnTextApplied(EventArgs.Empty);
        }
    }
