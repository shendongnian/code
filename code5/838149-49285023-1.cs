     protected void Page_Load(object sender, EventArgs e)  
        {  
            if (!Page.IsPostBack)  
            {  
                gvitems.DataSource = GetItemsRecord();  
                gvitems.DataBind();  
      
            }  
      
        }  
      
        public List<ITEM> GetItemsRecord()  
        {  
            BindGridViewDataContext db = new BindGridViewDataContext();  
            var listitemsrecord = (from x in db.ITEMs select x).ToList<ITEM>();  
            return listitemsrecord;  
      
        }  
