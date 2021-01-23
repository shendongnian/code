    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GenateGridView();
            else
            {
                string ctrlName = Request.Params.Get("__EVENTTARGET").Trim();
                if (!String.IsNullOrEmpty(ctrlName))
                {
                    if (ctrlName.StartsWith("lnkButton"))
                    {
                        GenateGridView();
                    }
                }
                
            }
        }
