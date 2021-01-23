    foreach (string row in rows)
    {
         var items = new List<string> { timeS };
         items.AddRange(row.Split(delimeter.ToArray()));
         speed = Convert.ToDouble(items[2]);
         speed = speed / 10;
         items[2] = speed.ToString();
         dataset.Tables[tableName].Rows.Add(items.ToArray());
         Dtime = Dtime.AddSeconds(inter);
    }
