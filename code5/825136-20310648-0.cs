           private void button2_Click(object sender, EventArgs e)
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CollegeDB.accdb;Persist Security Info=False;");
                OleDbCommand command=new OleDbCommand("insert into student values(@id,@name,@address)",con);
                con.Open();
                command.Parameters.AddWithValue("@id", 503);
                command.Parameters.AddWithValue("@name", "kumar");
                command.Parameters.AddWithValue("@address", "andhra");
                if(command.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("Row Inserted Succesfully!");
                }
                con.Close();
            }
