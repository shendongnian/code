    SqlCommand Cmd = Connection.CreateCommand();
    Cmd.CommandText = "Insert Into [TableName](Column1,Column2,Column3)Values(@Column1,Column2,Column3)";
    Cmd.Parameters.Add("@@Column1", SqlDbType.Int).Value = 1;
    Cmd.Parameters.Add("@@Column1", SqlDbType.Varchar).Value = "Shell";
    Cmd.Parameters.Add("@@Column1", SqlDbType.SmallDateTime).Value = System.DateTime.Now;
    Cmd.ExecuteNonQuery();
