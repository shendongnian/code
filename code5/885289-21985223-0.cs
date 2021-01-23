    var states = new List<string>();
    foreach (Object c in checkedListBox2.CheckedItems)
    {
        states.Add(c.ToString()); 
        flag = 1;  // Can also be substituted by states.Count > 0
    }
    
    using(var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\\Database\\LocNo.accdb"))
    {
        con.Open();
        using(var cmd = con.CreateCommand())
        {
            cmd.CommandText = "select distinct c1 from table where state IN (?)";
            cmd.Parameters.AddWithValue("States", string.Join(", ", states));
            using(var rdr = cmd.ExecuteReader())
            {
                var contacts = new List<string>();
                while(rdr.Read())
                {
                    contacts.Add(rdr.GetString(0);
                }
                label30.Text = string.Join(", ", contacts);
            }
        }        
    }
