      var myData = new DataTable();
            foreach (string field in fields)
            {
                myData.Columns.Add(field);
            }
            foreach (XmlNode node in nodeListItems)
            {
                // rs = RowSet
                if (node.Name == "rs:data")
                {
                    for (int i = 0; i < node.ChildNodes.Count; i++)
                    {
                        if (node.ChildNodes[i].Name == "z:row")
                        {
                            DataRow row = myData.NewRow();
                            foreach (string field in fields)
                            {
                                var xmlAttributeCollection = node.ChildNodes[i].Attributes;
                                if (xmlAttributeCollection != null)
                                    row[field] = xmlAttributeCollection["ows_" + field].Value;
                            }
                            myData.Rows.Add(row);
                        }
                    }
                }
            }
            return myData;
   
