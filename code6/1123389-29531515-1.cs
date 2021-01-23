    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            dynamic data = new[] {
                 new { ID = 1, Name ="Name_1"},
                   new { ID = 2, Name = "Name_2"},
                   new { ID = 3, Name = "Name_3"},
                   new { ID = 4, Name = "Name_4"},
                   new { ID = 5, Name = "Name_5"}
            };
     
            RadGrid1.DataSource = data;
     
        }
     
     
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(item["ButtonName"].Controls[0]);
     
            }
        }
     
     
        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Generate")
            {
                Response.ContentType = "text/plain";
                Response.AppendHeader("Content-Disposition", "attachment;filename= errorLog.txt");
                Response.AddHeader("content-length", "0");
                Response.Flush();
                Response.End();
            }
        }
