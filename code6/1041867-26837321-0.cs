    List<string> wheres = new List<string>();
    if (!string.IsNullOrWhiteSpace(PatientMobile.Text))
    {
        wheres.Add("phone_number LIKE @PatientMob");
        cmd.Parameters.Add(new MySqlParameter(@"PatientMob", MySqlDbType.VarChar)).Value = PatientMobile.Text;
    }
    ...
    string query = string.Format("SELECT * FROM Messages WHERE {0}", string.Join(" AND ", wheres));
