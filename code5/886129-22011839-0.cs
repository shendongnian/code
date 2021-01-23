    void tables()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Name") });
            dt.Rows.Add("John");
            dt.Rows.Add("Mike");
            dt.Rows.Add("Ann");
            dt.Rows.Add("Sam");
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Name") });
            dt1.Rows.Add("John");
            dt1.Rows.Add("John");
            dt1.Rows.Add("Mike");
            dt1.Rows.Add("Ann");
            dt1.Rows.Add("Ann");
            dt1.Rows.Add("Ann");
            DataTable dt2 = new DataTable();
            dt2.Columns.AddRange(new DataColumn[3] { new DataColumn("Name"), new DataColumn("Available"), new DataColumn("Count") });
            int count = 0;
            foreach (DataRow r in dt.Rows)
            {
                count = dt1.Select("Name='" + r[0].ToString() + "'").Count();
                if (count > 0)
                    dt2.Rows.Add(r[0].ToString(), "available", count.ToString());
                else
                    dt2.Rows.Add(r[0].ToString(), "unavailable", count.ToString());
            }
        }
