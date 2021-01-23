    SqlCommand cmd = new SqlCommand("c_get_all_item",oo.conn);
    cmd.CommandType = CommandType.StoredProcedure;
    oo.conn.Open();
 
    var adapter = new SqlDataAdapter(cmd);
    DataTable dt;
    adapter.Fill(dt);
    oo.Close()
    //Convert DataTable to a list of YourType
    List<YourType> data = dt.AsEnumerable().Select(s=> 
                             new YourType { 
                              Property1 = s.Field<FieldDataType>("item_name_id_pk"),
                              Property2 = s.Field<FieldDataType>("item_name_arabic"),
                                 ...
                             })
                             .ToList();
