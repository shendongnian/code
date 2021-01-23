        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                {
                    
                    gvnric.SelectedIndex = 0;
                    gvnric_SelectedIndexChanged(this, EventArgs.Empty);
                }
            }
        
