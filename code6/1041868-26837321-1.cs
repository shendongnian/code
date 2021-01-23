    List<string> wheres = new List<string>();
    List<MySqlParameter> parameters = new List<MySqlParameter>();
    if (!string.IsNullOrWhiteSpace(PatientMobile.Text))
    {
        wheres.Add("phone_number LIKE @PatientMob");
        parameters.Add(new MySqlParameter(@"PatientMob", MySqlDbType.VarChar)
                       {
                           Value = PatientMobile.Text
                       });
    }
    ...
    string query = string.Format("SELECT * FROM Messages WHERE {0}", string.Join(" AND ", wheres));
