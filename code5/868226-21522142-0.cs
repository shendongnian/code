    OleDbConnection conn1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Database.accdb");
            conn1.Open();
            string sql = "INSERT INTO notes ([time], [Header], [importance], [body]) " + "VALUES (?,?,?,?);";
            OleDbCommand cmd2 = new OleDbCommand(sql, conn1);
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("@time", OleDbType.Date).Value = DateTime.Parse(dateTimePicker1.Value);
            cmd2.Parameters.Add("@Header", OleDbType.VarChar).Value = textBox1.Text;
            cmd2.Parameters.Add("@importance", OleDbType.Integer).Value = int.Parse(comboBox1.Text);
            cmd2.Parameters.Add("@body", OleDbType.VarChar).Value = textBox2.Text;
            try
            {
                status = cmd2.ExecuteNonQuery();
                conn1.Close();
                if (status > 0)
                    MessageBox.Show("INSERT Command Executed Successfully!");
                else
                    MessageBox.Show("INSERT Command Failed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Close();
