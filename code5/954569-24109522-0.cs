     protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) 
            {
                 string url;
                 RadioButtonList rdl = new RadioButtonList();
                 url = rdl.SelectedItem.Text; 
            }  
        }
