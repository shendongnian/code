                static SPWeb _web;
                static SPSite _site;
                static SPList myList;
                static void Main(string[] args)
                {
                    string usercontrolvalue = "test";
                    _site = new SPSite("URL");
                    _web = _site.OpenWeb();
                    _web.AllowUnsafeUpdates = true;
                    myList = _web.Lists["MYList"];
                    SPListItem item = myList.Items.Add();
                    SPFieldUserValueCollection usercollection = new SPFieldUserValueCollection();
                    for (int i = 0; i < userarray.Length; i++)
                    {
                        SPUser usr = web.EnsureUser(userarray[i]);
                        SPFieldUserValue usertoadd = new SPFieldUserValue(_web, usr.ID, usr.Name);
                        if (usertoadd.User == null) // value is a SharePoint group if User is null
                        {
                            SPGroup group = web.Groups[usertoadd.LookupValue];
                            SPFieldUserValue groupValue = new SPFieldUserValue(_web, group.ID, group.Name);
                            usercollection.Add(groupValue);
                        }
                        else
                        {
                            usercollection.Add(usertoadd);
                        }
                    }
                    item["Approver"] = usercollection;
                    item.Update();
                }
