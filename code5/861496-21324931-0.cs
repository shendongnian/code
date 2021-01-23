    {
        static void Main(string[] args)
        {
            List<string> toReturn = new List<string>();
 
            toReturn.Add("UserID");
            toReturn.Add("UserName");
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("UserID"));
            dt.Columns.Add(new DataColumn("UserName"));
            DataRow row = dt.NewRow();
            row.ItemArray = toReturn.ToArray();
            dt.Rows.Add(row);
        }
    }
}
