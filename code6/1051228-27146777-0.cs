        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                imgBtn.Click -= ImageButton1_Click;   // remove previous handler
                imgBtn.Click +=imgBtnFw_Click_Details; // add new handler
            }
        }
     
