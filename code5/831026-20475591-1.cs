            SqlBulkCopy bulkCopy = new SqlBulkCopy("ConnectionString...");
            bulkCopy.DestinationTableName = "PhysicalTableName";
            DataTable dt = new DataTable("PhysicalTableName");
            
            dt.Columns.Add("ObjectId");
            dt.Columns.Add("Alias");
            dt.Columns.Add("DisplayName");
            dt.Columns.Add("TimeZone");
            dt.Columns.Add("Language");
            dt.Columns.Add("ListInDirectory");
            dt.Columns.Add("IsVmEnrolled");
                           
            
            XElement output = XElement.Load("c:\\temp\\input.xml");
            IEnumerable<XElement> users = output.Elements();
            foreach (XElement str in users)
            {
                DataRow dr = dt.NewRow();
                foreach (XElement node in str.Elements())
                {
                    dr[node.Name.LocalName] = node.Value;
                }
                dt.Rows.Add(dr);
            }
            bulkCopy.WriteToServer(dt);
