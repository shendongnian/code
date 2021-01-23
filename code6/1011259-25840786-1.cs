       private void btnUpdate_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data   Source=C:\Users\ALNETTE\Desktop\New folder\AccessDatabase.accdb");
            string Db = "UPDATE StudentInfo SET StudentName='SomeoneName' WHERE StudentID=1";
            OleDbCommand cmd = new OleDbCommand(Db, con); 
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error"+ex.Message);
            }
        }
