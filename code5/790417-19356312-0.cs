    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        XDocument x = XDocument.Load(Server.MapPath(@"~\App_Data\location.xml"));
        string ActiveUser = GetUsername();
        ArrayList ListOfNPSGroups = GetGroupsInOUByValue();
        ArrayList ActiveUserList = GetGroupmemberList(ListOfNPSGroups);
        x.Root.Descendants().Where(d => !ActiveUserList.Contains((string)d.Attribute("group")))
                             .ToList()
                             .ForEach(s => s.Remove());
            
        var data = (from item in x.Elements("plants").Elements("plant")
                   select new { display = item.Attribute("display").Value, id = item.Attribute("id").Value }).ToList();
        HiddenField hidden = e.Item.FindControl("HiddenField1") as HiddenField;
        if (hidden != null && !string.IsNullOrEmpty(hidden.Value))
        {
        DropDownList listViewDropDownListLocation  = e.Item.FindControl("ListViewDropDownListLocation") as DropDownList; 
            
        listViewDropDownListLocation.DataSource = data;
        listViewDropDownListLocation.DataTextField = "display";
        listViewDropDownListLocation.DataValueField = "id";
        listViewDropDownListLocation.DataBind();
        listViewDropDownListLocation.SelectedValue = hidden.Value;
        }
    }
