    XElement output = XElement.Load("c:\\temp\\input.xml");
    IEnumerable<XElement> users = output.Elements(); 
    
            DataTable dt = new DataTable();
                    dt.Columns.Add("CLIENT_INPUT_MHS_ID", typeof(int));
                    dt.Columns.Add("CLIENT_INPUT_MHS_GUID",typeof(Guid));
                    dt.Columns.Add("ITEM", typeof(string));
                    dt.Columns.Add("ITEM_ID", typeof(int));
                    dt.Columns.Add("ITEM_NUMBER", typeof(string));
                    dt.Columns.Add("CATEGORY", typeof(string));        
    
            foreach (XElement str in users)
            {
                DataRow dr = dt.NewRow();
                foreach (XElement node in str.Elements())
                {
                    dr[node.Name.LocalName] = node.Value;
                }
    
                dt.Rows.Add(dr);
            }
    SqlBulkCopy bulkCopy = new SqlBulkCopy("ConnectionString...");
     using (bulkCopy )
                    {
                        bulkCopy .BulkCopyTimeout = 0;
                        bulkCopy .ColumnMappings.Add(dt.Columns[0].ColumnName, "CLIENT_INPUT_MHS_ID");
                        bulkCopy .ColumnMappings.Add(dt.Columns[1].ColumnName, "CLIENT_INPUT_MHS_GUID");
                        bulkCopy .ColumnMappings.Add(dt.Columns[2].ColumnName, "ITEM");
                        bulkCopy .ColumnMappings.Add(dt.Columns[3].ColumnName, "ITEM_ID");
                        bulkCopy .ColumnMappings.Add(dt.Columns[4].ColumnName, "ITEM_NUMBER");
                        bulkCopy .ColumnMappings.Add(dt.Columns[5].ColumnName, "CATEGORY");
                        bulkCopy.DestinationTableName = "DestinationTableName";                   
                        bulkCopy.WriteToServer(dt); }
        
    
    Its working fine with my scenario.
