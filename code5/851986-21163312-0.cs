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
