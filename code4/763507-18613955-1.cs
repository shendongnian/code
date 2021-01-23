    var list = new List<MyListTable>();
    using (SqlConnection c = new SqlConnection(cString))
    using (SqlCommand cmd = new SqlCommand("SELECT KeyField, DisplayField FROM Table", c))
    {
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                list.Add(new MyListTable
                {
                    Key = rdr.GetString(0),
                    Display = rdr.GetString(1)
                });
            }
        }
    }
    var model = new users();
    model.DropDownList = new SelectList(list, "Key", "Display");
