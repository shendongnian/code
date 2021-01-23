    DirectorySearcher user_search1 = new DirectorySearcher(new DirectoryEntry(ldap_root1));
                    user_search1.Filter = String.Format("(&(!(userAccountControl:1.2.840.113556.1.4.803:=2))(objectCategory=user)(samaccountname={0}))", alias);
                    user_search1.SearchScope = SearchScope.Subtree;
                    user_search1.PropertiesToLoad.Add("memberOf");
                    user_search1.PropertiesToLoad.Add("objectSid");                  
                    user_search1.PropertiesToLoad.Add("userprincipalname");
                    SearchResult user_result1 = user_search1.FindOne();
                    DirectoryEntry entry1 = new DirectoryEntry(user_result1.Path);
                    foreach (var grp in entry1.Properties["memberOf"])
                    {
                        groupnames1.Append(((grp.ToString().Split('=')[1].Split(',')[0])));
                        groupnames1.Append(";");
                        DirectorySearcher Groupsearch = new DirectorySearcher(new DirectoryEntry(ldap_root1));
                        Groupsearch.Filter = String.Format("(&(!(userAccountControl:1.2.840.113556.1.4.803:=2))(objectCategory=group)(samaccountname={0}))", ((grp.ToString().Split('=')[1].Split(',')[0])));
                        Groupsearch.SearchScope = SearchScope.Subtree;
                        Groupsearch.PropertiesToLoad.Add("memberOf");
                        SearchResult group_result1 = Groupsearch.FindOne();
                        if (group_result1 != null)
                        {
                            DirectoryEntry group1 = new DirectoryEntry(group_result1.Path);
                            //group1.RefreshCache(new string[] { "tokenGroups" });
                            //groupnames = null;
                            foreach (var grp1 in group1.Properties["memberOf"])
                            {
                                groupnames1.Append(((grp1.ToString().Split('=')[1].Split(',')[0])));
                                groupnames1.Append(";");
                            }
                        }
                    }
                    return groupnames1.ToString().Substring(0, groupnames1.Length - 1);
