            using(var ds = new DirectorySearcher())
            {
                ds.SearchRoot = new DirectoryEntry("");
                ds.Filter = "(|(&(objectCategory=printQueue)(name=*)))";
                ds.PropertiesToLoad.Add("printername");
                ds.PropertiesToLoad.Add("portname");
                ds.PropertiesToLoad.Add("servername");
                ds.PropertiesToLoad.Add("cn");
                ds.PropertiesToLoad.Add("name");
                ds.PropertiesToLoad.Add("printsharename");
                ds.ReferralChasing = ReferralChasingOption.None;
                ds.Sort = new SortOption("name", SortDirection.Descending);
                using(var src = ds.FindAll())
                {
                    foreach(SearchResult sr in src)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(sr.GetDirectoryEntry().Name);
                        foreach (DictionaryEntry p in sr.Properties)
                        {
                            var propName = p.Key;
                            var propCollection = (ResultPropertyValueCollection)p.Value;
                            var propValue = propCollection.Count > 0 ? propCollection[0] : "";
                            Console.WriteLine(propName);
                            Console.WriteLine(propValue);
                        }
                        Console.WriteLine("------------------------------------");                        
                    }
                }
            }
