     protected void Page_Load(object sender, EventArgs e)
            {
                if (Page.IsPostBack)
                    return;
    
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }
 
    public void Tmaincontent_Tick(object sender, EventArgs e)
            {
                if (Panel1.Visible)
                {
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    UPmaincontent.Update();
                    return;
                }
    
                if (Panel2.Visible)
                {
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    UPmaincontent.Update();
                    return;
                }
            
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
                UPmaincontent.Update();
    
            }
