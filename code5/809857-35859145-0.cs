        Below function will return you DataTable. 
        
        internal DataTable GetDataTableFromListItemCollection()
                {
                    string strWhere = string.Empty;
                    DataTable dtGetReqForm = new DataTable();
                    using (var clientContext = new ClientContext("sharepoint host url"))
                    {
                        try
                        {
                            Microsoft.SharePoint.Client.List spList = clientContext.Web.Lists.GetByTitle("ReqList");
                            clientContext.Load(spList);
                            clientContext.ExecuteQuery();
        
                            if (spList != null && spList.ItemCount > 0)
                            {
                                Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
                                camlQuery.ViewXml =
                                @"<View>" +
                                "<Query> " +
                                    "<Where>" +
                                        "<And>" +
                                                "<IsNotNull><FieldRef Name='ID' /></IsNotNull>" +
                                                "<Eq><FieldRef Name='ReqNo' /><Value Type='Text'>123</Value></Eq>" +
                                        "</And>" +
                                    "</Where>" +
                                "</Query> " +
                                "<ViewFields>" +
                                    "<FieldRef Name='ID' />" +
                                "</ViewFields>" +
                                "</View>";
        
                                SPClient.ListItemCollection listItems = spList.GetItems(camlQuery);
                                clientContext.Load(listItems);
                                clientContext.ExecuteQuery();
        
                                if (listItems != null && listItems.Count > 0)
                                {
                                    foreach (var field in listItems[0].FieldValues.Keys)
                                    {
                                        dtGetReqForm.Columns.Add(field);
                                    }
        
                                    foreach (var item in listItems)
                                    {
                                        DataRow dr = dtGetReqForm.NewRow();
        
                                        foreach (var obj in item.FieldValues)
                                        {
                                            if (obj.Value != null)
                                            {
                                                string key = obj.Key;
                                                string type = obj.Value.GetType().FullName;
        
                                                if (type == "Microsoft.SharePoint.Client.FieldLookupValue")
                                                {
                                                    dr[obj.Key] = ((FieldLookupValue)obj.Value).LookupValue;
                                                }
                                                else if (type == "Microsoft.SharePoint.Client.FieldUserValue")
                                                {
                                                    dr[obj.Key] = ((FieldUserValue)obj.Value).LookupValue;
                                                }
                                                else if (type == "Microsoft.SharePoint.Client.FieldUserValue[]")
                                                {
                                                    FieldUserValue[] multValue = (FieldUserValue[])obj.Value;
                                                    foreach (FieldUserValue fieldUserValue in multValue)
                                                    {
                                                        dr[obj.Key] += (fieldUserValue).LookupValue;
                                                    }
                                                }
                                                else if (type == "System.DateTime")
                                                {
                                                    if (obj.Value.ToString().Length > 0)
                                                    {
                                                        var date = obj.Value.ToString().Split(' ');
                                                        if (date[0].Length > 0)
                                                        {
                                                            dr[obj.Key] = date[0];
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    dr[obj.Key] = obj.Value;
                                                }
                                            }
                                            else
                                            {
                                                dr[obj.Key] = null;
                                            }
                                        }
                                        dtGetReqForm.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {
                            if (clientContext != null)
                                clientContext.Dispose();
                        }
                    }
                    return dtGetReqForm;
        
                }
    
    //once you have the DataTable() with you you can set the DataSource 
    
    //DataGridView1 is the id value
    
    DataGridView1.DataSource = GetDataTableFromListItemCollection(); 
