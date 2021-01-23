    private int Count
    {
      get 
       {
         if (Session["Count"] == null)
         {         Session["Count"] = 0; return 0;      }
         else 
            return (int)Session["Count"] ; 
       }
       set
       {
          Session["Count"] = value;
       }
    } 
    
    protected void Page_Load(object sender, EventArgs e)     
    {
        if(!IsPostBack)
            Count = 0; 
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
         Count++; 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
         Count++; 
    }
