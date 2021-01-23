    protected void addSomeControls()    //done in original page_load so bind data
        {
            DropDownList dl = new DropDownList();
            dl.SelectedIndexChanged += new EventHandler(dlOnSelectedIndexChange);
            dl.EnableViewState = true;
            dl.AutoPostBack = true;
            this.NumberOfControls++;
            dl.ID = "ControlID_" + this.NumberOfControls.ToString();
            using (I.DBEntities1 ctx = new I.DBEntities1())
            {
                dl.DataSource = ctx.Lk_PersonPersonAssocType.OrderBy(c => c.Assoc_Type);
                dl.DataValueField = "ID";
                dl.DataTextField = "Assoc_Type";
                dl.DataBind();
            }
            
            DynamicControlsHolder.Controls.Add(dl);
            DynamicControlsHolder.EnableViewState = true;
        }
        protected void createControls()   //postback, rely upon viewstate here
        {
            int count = this.NumberOfControls;
       
            for (int i = 0; i < count; i++)
            {
                DropDownList dl = new DropDownList();
                dl.SelectedIndexChanged += new EventHandler(dlOnSelectedIndexChange);
                dl.AutoPostBack = true;
            using (I.DBEntities1 ctx = new I.DBEntities1())
            {
                dl.DataSource = ctx.Lk_PersonPersonAssocType.OrderBy(c => c.Assoc_Type);
                dl.DataValueField = "ID";
                dl.DataTextField = "Assoc_Type";
                dl.DataBind();
            }
            dl.ID = "ControlID_" + NumberOfControls.ToString();
            
            DynamicControlsHolder.Controls.Add(dl);
            }
        }
