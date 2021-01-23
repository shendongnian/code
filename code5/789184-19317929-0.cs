    Got the answer....
    I am just creating a list of dictionary type and adding multiple values in it.
     
     Dictionary<string, string> ds = null; 
     List<Dictionary<string, string>> lsb = new List<Dictionary<string, string>>();
     foreach (var entity in abc.Object)
                                {
                                    foreach (var objAddress in entity.Addresses)
                                    {
                                         ds.Add("City", (objAddress.City == null) ? "" : objAddress.City);
                                        ds.Add("State", (objAddress.State == null) ? "" : objAddress.State.ToString());
                                        lsb.Add(ds);
                                    }
