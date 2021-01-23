    ConDb.Open();
                     OleDbCommand DBSelect = new System.Data.OleDb.OleDbCommand("select FName, LName,ID_NAME from NameList", ConDb);
                     OleDbDataReader reader = DBSelect.ExecuteReader();
                     while (reader.Read())
                     {
                         string eNAME = "";
                         eID = reader["ID_NAME"].ToString();
                         eNAME += reader["FName"].ToString();
                         eNAME += " " + reader["LName"].ToString();
                         MyComboBoxData.Add(eNAME);
                     }
                 }
