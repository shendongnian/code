    protected void Page_Load (object sender, EventArgs e)
    {
        PreRender += new EventHandler(_Default_PreRender);
    
        textboxes = new List<TextBox>();
    
        if (IsPostBack)
        {
            //recreate Textboxes
            int count = Int32.Parse(ViewState["tbCount"].ToString());
    
            for (int i = 0; i < count; i++)
            {
                TextBox tb = new TextBox();
                tb.ID = "tb" + i;
    
                Panel1.Controls.Add(tb);
    
                textboxes.Add(tb);
    
                tb.Text = Request.Form[tb.ClientID];
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //create new textbox
        TextBox tb = new TextBox();
        tb.ID = "tb" + textboxes.Count;
    
        Panel1.Controls.Add(tb);
    
        textboxes.Add(tb);        
    }
    void _Default_PreRender(object sender, EventArgs e)
    {
        //remember how many textboxes we had
        ViewState["tbCount"] = textboxes.Count;
    }
