    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showFindInfoMessage();
        }
    
        public delegate void myDelegate();
        public event myDelegate FindInfo;
    
        protected void btnOne_Click(object sender, EventArgs e)
        {
            FindInfo += new myDelegate(showFindInfoMessage);
            FindInfo += new myDelegate(showWebsite);
            FindInfo();
        }
    
        public void showFindInfoMessage()
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "scriptkey", "alert('You will now be redirected to the website!')");
        }
    
        public void showWebsite()
        {
            string web = "https://facebook.com/";
    
            Response.Redirect(web);
        }
    }
