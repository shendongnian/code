        List<string> bob=new List<string>();
     foreach (DataRow rows in ds.Rows)
        {
            foreach (var item in rows.ItemArray)
            {
                count += 1;
                //bob[count] = item.ToString();
                bob.Add(item.ToString());
            }
        }
