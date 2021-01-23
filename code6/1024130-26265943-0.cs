    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
           Label1.Text = "Click the button";
        }
    }
