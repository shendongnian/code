    protected void cbxSelect_CheckedChanged(object sender, EventArgs e)
            {
    
            SubMenuGrid.DataSource = null;
            SubMenuGrid.DataBind();
    
            Business.SubMenuModules sub = new Business.SubMenuModules();
    
            List<oSubList> oList = new List<oSubList>();
    
            int counter = 0;
    
            foreach (GridViewRow nRow in gvModuleList.Rows)
            {
                Int32 intModID = Convert.ToInt32(nRow.Cells[0].Text);
                CheckBox chkBx = (CheckBox)nRow.FindControl("cbxSelect");
    
                if (chkBx.Checked == true)
                {
                    counter = counter + 1;
    
                    var oModList = sub.GetAllMenuPerModuleID(intModID);
    
                    if (oModList.Count > 0)
                    {
    
                        foreach (var rec in oModList)
                        {
                            oSubList olist = new oSubList
                            {
                                ID = rec.ID,
                                ModuleID = rec.ModuleID,
                                Submenu = rec.Submenu,
                                Description = rec.Description
                            };
                            oList.Add(olist);    
                        }
    
                        Session["list"]=oList;
    
                        SubMenuGrid.DataSource = oList;
                        SubMenuGrid.DataBind();
                    }
                }
