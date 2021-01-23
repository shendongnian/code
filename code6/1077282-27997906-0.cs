            string qry = "select * from [table]";
            DataTable vt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(q, connectionString);
            da.Fill(vt);
            foreach (DataRow row in vt.Rows)
            {
                if (Convert.ToDateTime(row["DATE"].ToString()) >= Convert.ToDateTime(FromDate)
                    && Convert.ToDateTime(row["DATE"].ToString()) <= Convert.ToDateTime(ToDate))
                {
                    continue;
                }
                else
                {
                    row.Delete();
                }
            }
            vt.AcceptChanges();
