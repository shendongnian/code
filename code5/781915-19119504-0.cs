    private void DoSomething()
    {
        DataTable table = (DataTable)grid.DataSource;
        foreach (DataRow row in table.Rows)
        {
           Data.SomethingA item = new Data.SomethingA
           {
               item.ac = Convert.ToUInt32(row[5].ToString())
           };
           item.ad = Convert.ToUInt32(row[2].ToString()[7].ToString());
           item.ab = row[1].ToString();
           item.az = row[3].ToString();
           item.ae = Convert.ToUInt32(row[4].ToString());
           item.aq = row[6].ToString();
           ABC.Add(item);
        }
    }
