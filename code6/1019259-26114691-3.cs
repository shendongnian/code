            DataTable dt = new DataTable();
            dt.Columns.Add("AdjusterEmail", typeof(string));
            dt.Columns.Add("EmpCode", typeof(string));
            dt.Columns.Add("SOJ", typeof(string));
            dt.Columns.Add("DOI", typeof(string));
            dt.Columns.Add("GPI", typeof(string));
            dt.Columns.Add("BlockCode", typeof(string));
            
            DataRow dr = null;
            foreach (var readValue in records)
            {
                dr = dt.NewRow();
                dr["AdjusterEmail"] = readValue.AdjusterEmail;
                dr["EmpCode"] = readValue.EmpCode;
                dr["SOJ"] = readValue.SOJ;
                dr["DOI"] = readValue.DOI;
                dr["GPI"] = readValue.GPI;
                dr["BlockCode"] = readValue.BlockCode;
                dt.Rows.Add(dr);
             }
