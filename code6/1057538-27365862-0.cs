            using (MySqlConnection cnn = new MySqlConnection(dbConnectionString))
            {
                cnn.Open();
                MySqlCommand command = new MySqlCommand(select, cnn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    db1 = (now - Convert.ToDateTime(reader["Nuo"])).TotalDays;
                    MessageBox.Show(db1.ToString());
                    db1 = db1 - Convert.ToInt32(reader["Ivikio diena"]);
                    MessageBox.Show(db1.ToString());
                    b = Convert.ToInt32(db1) / Convert.ToInt32(reader["Periodiskumas_d"]);
                    MessageBox.Show(b.ToString());
                    a = +Convert.ToInt32(reader["Suma"]);
                    MessageBox.Show(a.ToString());
                    a = a * b;
                    MessageBox.Show(a.ToString());
                }
                string prideti = "Update Lesos Set Grynieji=Grynieji + '" + a + "'";
                MySqlCommand prideti_cmd = new MySqlCommand(prideti, cnn);
                string p = prideti_cmd.ExecuteNonQuery().ToString();
                string update = "UPDATE Ivikiai Set `Ivykio diena`+= '" + db1 + "'";
                MySqlCommand update_cmd = new MySqlCommand(update, cnn);
                string u = update_cmd.ExecuteNonQuery().ToString();
            }
