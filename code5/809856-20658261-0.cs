            ListItemCollection items = GetListItemCollections(); //Get list item collection
            DataTable dt = new DataTable();
            foreach (var field in items[0].FieldValues.Keys)
            {
                dt.Columns.Add(field);
            }
            foreach (var item in items)
            {
                DataRow dr = dt.NewRow();
                foreach (var obj in item.FieldValues)
                {
                    if (obj.Value != null)
                    {
                        string type = obj.Value.GetType().FullName;
                        if (type == "Microsoft.SharePoint.Client.FieldLookupValue")
                        {
                            dr[obj.Key] = ((FieldLookupValue)obj.Value).LookupValue;
                        }
                        else if (type == "Microsoft.SharePoint.Client.FieldUserValue")
                        {
                            dr[obj.Key] = ((FieldUserValue)obj.Value).LookupValue;
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
                dt.Rows.Add(dr);
            }
            ResetDataGridView(); //Clear contents of datagridview
            dataGridView1.DataSource = dt;
