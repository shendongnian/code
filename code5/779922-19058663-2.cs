    var list = new List<object>();
    combobox1.ValueMember = "Id";
    combobox1.DisplayMember = "FullName";
    while (dr.Read())
    {
       list.Add(
           new {
                  FullName = dr.GetString(1) + " " + dr.GetString(2), 
                  Id = dr.GetInt32(0)
                });
     }
    combobox1.DataSource = list;
