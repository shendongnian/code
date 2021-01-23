    string connection = ConfigurationManager.ConnectionStrings["ADConnection"].ToString();
    DirectorySearcher dssearch = new DirectorySearcher(connection);
    dssearch.Filter = "(&(objectCategory=Person))";
    dssearch.Filter = "(sAMAccountName=" + current_User + ")";
 
    SearchResultCollection searchResult = dssearch.FindAll();
    foreach (SearchResult srUSers in searchResult)
    {
        DirectoryEntry de = srUsers.GetDirectoryEntry();
        dropDownList1.Items.Add(de.Name.ToString());
    }
