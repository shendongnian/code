    objGroupEntry = sr.GetDirectoryEntry();
    dso = new DirectorySearcher(objGroupEntry);
                        
    dso.ClientTimeout = TimeSpan.FromSeconds(30);
    dso.PropertiesToLoad.Add("physicalDeliveryOfficeName");
    dso.PropertiesToLoad.Add("otherFacsimileTelephoneNumber");
    dso.PropertiesToLoad.Add("otherTelephone");
    dso.PropertiesToLoad.Add("postalCode");
    dso.PropertiesToLoad.Add("postOfficeBox");
    dso.PropertiesToLoad.Add("streetAddress");
    dso.PropertiesToLoad.Add("distinguishedName");
                    
    dso.SearchScope = SearchScope.OneLevel;
    dso.Filter = "(&(objectClass=top)(objectClass=person)(objectClass=organizationalPerson)(objectClass=user))";
    dso.PropertyNamesOnly = false;
                    
    SearchResult pResult = dso.FindOne();
 
    if (pResult != null)
    {
        offEntry = pResult.GetDirectoryEntry();
        foreach (PropertyValueCollection o in offEntry.Properties)
        {
            this.Controls.Add(new LiteralControl(o.PropertyName + " = " + o.Value.ToString() + "<br/>"));
        }
    }
