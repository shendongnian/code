            try
            {
                conDataBase.Open();
                myReader = cmdDatabase.ExecuteReader();
                // You're missing this line!
                Talent_Name.Items.Clear();
                while (myReader.Read())
                {
                    string talent_name = myReader.GetString("Talent_Name");
                    Talent_Name.Items.Add(talent_name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \r\n" + ex);
            }
