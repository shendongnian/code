            int rowcount = 0;
            DataTable dt = new DataTable("ReferenceData");
            dt.Columns.Add("ReferenceID");
            dt.Columns.Add("ReferenceDescription");
            dt.Columns.Add("ReferenceUrl");
            dt.Columns.Add("SortOrder");
            
            dt.Rows.Add("0", "Interdiscip", "http://www.ncbi.nlm.nih.gov/", "1");
            dt.Rows.Add("0", "Entropy 20133", "http://www.mdpi.com/1099-4300", "2");
            dt.Rows.Add("0", "Interdiscip", "http://www.ncbi.nlm.nih.gov/", "3");
            dt.Rows.Add("0", "Agriculture", "http://www1.agric.gov.ab.ca/", "4");
            dt.Rows.Add("0", "Interdiscip", "http://www.ncbi.nlm.nih.gov/", "5");
            DataSet ds = new DataSet();
            DataTable dtOut = null;
            ds.Tables.Add(dt);
            
            DataView dv = dt.DefaultView;
            dv.Sort = "ReferenceDescription,ReferenceUrl";
            dtOut = dv.ToTable();
                       
            dt = dv.ToTable();
            
            for (int t = 0; t < dtOut.Rows.Count; t++)
            {
                int i = 0;
                int count = 0;
                int sortorder = 0;
                string space = null;
                string x = dtOut.Rows[t][1].ToString();
                string y = dtOut.Rows[t][2].ToString();
                sortorder = Convert.ToInt32(dtOut.Rows[rowcount][3]);
                for (int j = 0; j < dtOut.Rows.Count; j++)
                {
                    if (x == dtOut.Rows[j][1].ToString() && y == dtOut.Rows[j][2].ToString())
                    {
                        count = dtOut.AsEnumerable().Where(s => s.Field<string>("ReferenceDescription").EndsWith(x) && s.Field<string>("ReferenceUrl") == y).Count();
                        //count++;
                        if (count > 1)
                        {
                            sortorder = Convert.ToInt32(dtOut.Rows[j][3]);
                            space += sortorder + " ";
                            dtOut.Rows[j].Delete();
                            dtOut.AcceptChanges();
                        }
                    }
                    i++;
                }
                dtOut.Rows[rowcount][1] = space + x;
                rowcount++;
            }
