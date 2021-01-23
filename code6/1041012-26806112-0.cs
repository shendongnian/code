    protected void lvProjectServices_ItemCreated(object sender, ListViewItemEventArgs e)
        {
          
                if (e.Item.DataItem != null)
                {
                    Whatever data = (Whatever)e.Item.DataItem;
                    PlaceHolder objPlc3 = (PlaceHolder)e.Item.FindControl("phEdit");
                    LinkButton link3 = new LinkButton();
                    link3.Text = "<i class=\"table-edit\"></i>";
                    link3.ID = "lbEditServer" + data.Id.ToString();
                    link3.CommandName = "Edit";
                    link3.CommandArgument = data.Id.ToString();
                    link3.Click += link_Click;
                    objPlc3.Controls.Add(link3);
                }
            }
        
        void link_Click(object sender, EventArgs e)
        {
            
            LinkButton btn = (LinkButton)sender;
            int Id = int.Parse(btn.CommandArgument.ToString());
            txtProjectServiceId.Value = Id.ToString();
                ScriptManager scriptManager = ScriptManager.GetCurrent(Page);
                if (!scriptManager.IsClientScriptBlockRegistered("openSvcModal"))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "openSvcModal", "$('select').select2(); $('#editProjectService').modal();", true);
                }
        }
