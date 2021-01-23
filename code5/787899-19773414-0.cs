    private Dictionary<String, AssignmentData> OUDictionary = new Dictionary<String, AssignmentData>();
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
                    OUDictionary.Add(reader[2].ToString(), newItem);
                }
                reader.Close();
                reader.Dispose();
                foreach (AssignmentData d in OUDictionary.Values)
                {
                    String parentKey = GetParentLDAPKey(d.AssignmentLDAPPath);
                    if (OUDictionary.ContainsKey(parentKey))
                    {
                        if (OUDictionary[parentKey] != null)
                        {
                            AssignmentData parentItem = OUDictionary[parentKey];
                            if (parentItem.Children == null)
                            {
                                //add first child
                                parentItem.Children = new ObservableCollection<AssignmentData> { d };
                            }
                            else
                            {
                                //add more children to exisiting
                                parentItem.Children.Add(d);
                            }
                        }
                    }
                    else
                    {
                        UserOUCollection.Add(d);
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
