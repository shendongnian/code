    string x = item["SP_Group"] == null ? "" : item["SP_Group"].ToString();
                    if (x != "")
                    {
                        SPFieldUserValue uv = new SPFieldUserValue(web, x);
                        SPGroup group = mySite.Groups.GetByID(uv.LookupId);
                        if (group.Users.Count > 0)
                        {
                            System.Collections.ArrayList entityArrayList = new System.Collections.ArrayList();
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                foreach (SPUser sUser in group.Users)
                                {
                                    PickerEntity entity = new PickerEntity();
                                    entity.Key = sUser.LoginName;
                                    entity = peopleEditor.ValidateEntity(entity);
                                    entityArrayList.Add(entity);
                                }
                            });
                            peopleEditor.UpdateEntities(entityArrayList);
                            peopleEditor.Validate();
                        }
                        else
                        {
                            peopleEditor.Entities.Clear();
                        }
                    }
----------
    string x = item["SP_Users"] == null ? "" : item["SP_Users"].ToString();
                    if (x != "")
                    {
                        SPFieldUserValueCollection uvcoll = new SPFieldUserValueCollection(mySite, x);                       
                        if (uvcoll.Count > 0)
                        {
                            System.Collections.ArrayList entityArrayList = new System.Collections.ArrayList();
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                foreach (SPFieldUserValue uv in uvcoll)
                                {
                                    SPUser sUser = uv.User;
                                    PickerEntity entity = new PickerEntity();
                                    entity.Key = sUser.LoginName;
                                    entity = peopleEditor.ValidateEntity(entity);
                                    entityArrayList.Add(entity);
                                }
                            });
                            peopleEditor.UpdateEntities(entityArrayList);
                            peopleEditor.Validate();
                        }
                        else
                        {
                            peopleEditor.Entities.Clear();
                        }
                    }
