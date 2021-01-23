     string query = string.Format("SELECT * FROM MESSAGE WHERE {0}", string.Join(" AND ", wheres));
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.Add(new MySqlParameter(@"PatientMob", MySqlDbType.VarChar)).Value = PatientMobile.Text;
                    cmd.Parameters.Add(new MySqlParameter(@"UserID", MySqlDbType.VarChar)).Value = UserID.Text;
