    using (DirectorySearcher ds = new DirectorySearcher())
            {
                //My original filter
                //ds.Filter = string.Format("(|(&(objectClass=group)(|(samaccountname=*{0}*)(displayname=*{0}*)))(&(objectCategory=person)(objectClass=user)(|(samaccountname=*{0}*)(displayname=*{0}*))))", name);
                
                //Your Modified filter                
                ds.filter = "(objectCategory=User)"
 
                ds.PropertiesToLoad.Add("displayname");
                ds.SizeLimit = 20;
                SearchResultCollection result = ds.FindAll();
                List<string> names = new List<string>();
                foreach (SearchResult r in result)
                {
                    var n = r.Properties["displayname"][0].ToString();
                    if (!names.Contains(n))
                        names.Add(n);
                }
                return Json(names, JsonRequestBehavior.AllowGet);
            }
