    while (sqlrdr.Read())
    {
        string tableValue = sqlrdr[0].ToString();
        bool found = listBox1.Items.Cast<object>().Any(x=>x.ToString() == tableValue);
        if(found)
        {
            //Search found do whatever
        }
        else
        {
            //Search not found do whatever
        }
    }
