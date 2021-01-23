    private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                string constring = "Data Source=localhost;User Id=root;Password=sulyman;database=accounting_db";
                string file = "D:\\backup.sql";
                using(MySqlConnection conn = new MySqlConnection(constring))                
                using(MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open(); //dal.Open();
                    using(MySqlBackup ba = new MySqlBackup(cmd))
                    {
                       ba.ExportToFile(file);
                       //dal.close();
                       MessageBox.Show("done");
                    }
                }
 
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }
