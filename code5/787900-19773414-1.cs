    Dictionary<String, AssignmentData> OUDictionary = new Dictionary<String, AssignmentData>();
    //Read from DB
    cmd = new SqlCommand("SELECT UserGroups.UserGroupID, UserGroups.Name, UserGroups.LDAPPath FROM UserGroups WHERE UserGroups.TypeID=1", DBCon);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AssignmentData newItem = new AssignmentData()
                            {
                                AssignmentID = Convert.ToInt32(reader[0]),
                                AssignmentName = reader[1].ToString(),
                                AssignmentImage = ouIcon,
                                AssignmentLDAPPath = reader[2].ToString(),
                                AssignmentCNPath = GetCNFromLDAPPath(reader[2].ToString()),
                                AssignmentTooltip = GetADSLocationTooltip(reader[2].ToString()),
                                AssignmentType = AssignmentTypes.UserOU,
                            };
                    UserOUDictionary.Add(reader[2].ToString(), newItem);
                }
                reader.Close();
                reader.Dispose();
                //Now Read OU List into TreeView Collection
                foreach (AssignmentData d in UserOUDictionary.Values)
                {
                    String parentKey = GetParentLDAPPath(d.AssignmentLDAPPath);
                    if (UserOUDictionary.ContainsKey(parentKey))
                    {
                        AssignmentData parentItem = UserOUDictionary[parentKey];
                        if (parentItem.Children == null) { parentItem.Children = new ObservableCollection<AssignmentData> { d }; } //add first child
                        else { parentItem.Children.Add(d); } //add more children to exisiting
                    }
                    else
                    {
                        UserOUCollection.Add(d); //add to root of control
                    }
                }
    private String GetParentLDAPKey(String strLDAPPath)
        {
            String retParentKey = strLDAPPath;
            if (strLDAPPath.Contains(","))
            {
                retParentKey = retParentKey.Replace("LDAP://", "");
                retParentKey = retParentKey.Remove(0, retParentKey.IndexOf(",") + 1);
                retParentKey = "LDAP://" + retParentKey;
            }
            return retParentKey;
        }
