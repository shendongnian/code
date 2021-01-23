    Dictionary<string, Dictionary<string, List<string>>> dictPage = new Dictionary<string, Dictionary<string, List<string>>>();
    
    foreach (DataRow row in dt.Rows)
    {
    	string sPageID = row["PageName"].ToString();
    	string sVersionID = row["VersionName"].ToString();
    	string sElementID = row["ElementName"].ToString();
    
    	if (!dictPage.ContainsKey(sPageID))
    		dictPage.Add(sPageID, new Dictionary<string, List<string>>());
    
    	if (!dictPage[sPageID].ContainsKey(sVersionID))
    		dictPage[sPageID].Add(sVersionID, new List<string>());
    
    	dictPage[sPageID][sVersionID].Add(sElementID);
    }
