    private void Page_Load()
    {
       //check if this is a post back
       if(this.IsPostBack)
        {
           //restore your values
           TextBox1.Text = (string)Session["TextBox1"];
        }
    }
