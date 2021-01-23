    private void button3_Click(object sender, EventArgs e)
    {
     DateTime a = dateTimePicker1.Value.Date;
     using(OleDbConnection conn = new
     OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data
     Source=C:\Users\Kolton\Desktop\Doctor App\Database1.accdb")) 
     {
            for (int i = 0; i < 366; i++)
            {
                DateTime b = a.AddDays(i);
                string c = b.ToShortDateString();
    
                using (System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand())
                {
    
    
                    cmd.Connection = conn;
                    cmd.CommandText = "Insert Into Times (Date1) values ('" + c + "')";
    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
    
            }
        }
      }
