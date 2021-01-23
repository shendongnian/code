    protected void Page_Load(object sender, EventArgs e)
    {       
       if(!Page.IsPostBack) {
          Panel1.Visible = True;
          Panel2.Visible = false;
          LoadQuestion(); // auto choose question from database and add into Panel1
          LoadQuestion1();  // auto choose question from database and add into Panel2 
       }                      
    }
