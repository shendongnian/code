    try
            {
                string combo;
                if (comboBox1.Text== "Random Pool")
                {
                    combo = "10";
                }
                if (comboBox1.Text== "Other")
                {
                    combo = "20";
                }
                if (comboBox1.Text== "DOT Pool")
                {
                    combo = "30";
                }
                if (comboBox1.Text== "Follow up")
                {
                    combo = "40";
                }
                if (comboBox1.Text== "Pre-employement Screening")
                {
                    combo = "50";
                }
                if (comboBox1.Text== "Aberrant Behavior")
                {
                    combo = "60";
                }
                if (comboBox1.Text== "Incident/Near Miss Investigation")
                {
                    combo = "70";
                }
                if (comboBox1.Text== "Investigation")
                {
                    combo = "80";
                }
                else
                {
                    combo = "20";
                }
                string cmdstring = "INSERT INTO Test (SELECTION_DATE, TEST_REASON_CODE, PEOPLESOFT_EMPL_ID, TEST_TYPE_CODE) VALUES(@date, '" + combo + "', @emp, 10);";
                using (OleDbCommand cmd = new OleDbCommand(cmdstring, con))
                {
    
                    cmd.Parameters.Add("@date", OleDbType.Date).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@emp", OleDbType.Char).Value = textBox1.Text;
    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Submitted Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to " + ex.Message);
            } 
