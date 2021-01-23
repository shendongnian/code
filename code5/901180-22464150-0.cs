    tring[] ids = dt.AsEnumerable()
                                .Select(row => row["ProductID"].ToString())
                                .ToArray();
        for (int i = 0; i < ids.Length; i++) {
            string val = ids[i];
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.CommandText = "Delete from tblindividualproduct where ProductID = @p1";
            cmd1.Parameters.AddWithValue("@p1", val);
        }
