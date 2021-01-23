        public int level(DataTable dt, DataRow row)
        {
            int parentid = int.Parse(row[2].ToString());
            if (parentid == 0)
                return 1;
            else
                return 1 + level(dt, GetDataRow(dt,parentid ));
        }
        public DataRow GetDataRow(DataTable dt, int id)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (int.Parse(r[0].ToString()) == id) return r;
            }
            return null;
        }
