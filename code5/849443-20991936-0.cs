     public partial class TestUC : System.Web.UI.UserControl
    {
        public String Text
        {
            get
            {
                return this.txtbox1.Text;
            }
        }
        public delegate void TextAppliedEventHandler(Object sender, EventArgs e);
        public event EventHandler TextApplied;
        protected virtual void OnTextApplied(EventArgs e)
        {
            
            if (TextApplied != null)
                TextApplied(this, e);
        }
        
        protected void btn1_Click(object sender, EventArgs e)
        {
            OnTextApplied(EventArgs.Empty);
        }
    }
