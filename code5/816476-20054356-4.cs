    private string GenerateMenu(DataRow[] drParentMenu, DataTable oDataTable, StringBuilder oStringBuilder)
    {
    oStringBuilder.AppendLine(“<ul>”);if (drParentMenu.Length > 0)
    {
    foreach (DataRow dr in drParentMenu)
    {
    string MenuURL = dr["URL"].ToString();
    string MenuName = dr["Name"].ToString();
    string line = String.Format(@”<li ><a href=”"{0}”">{1}</a>”, MenuURL, MenuName);
    oStringBuilder.Append(line);
    string MenuID = dr["MenuID"].ToString();
    string ParentID = dr["ParentID"].ToString();
    DataRow[] subMenu = oDataTable.Select(String.Format(“ParentID = {0}”, MenuID));
    if (subMenu.Length > 0 && !MenuID.Equals(ParentID))
    {
    var subMenuBuilder = new StringBuilder();
    oStringBuilder.Append(GenerateMenu(subMenu, oDataTable, subMenuBuilder));
    }
    oStringBuilder.Append(“</li>”);
    
    }
    }
    oStringBuilder.Append(“</ul>”);
    return oStringBuilder.ToString();
    }
