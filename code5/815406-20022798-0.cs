    SqlCeConnection sqlCnn = new SqlCeConnection("Data Source=" + Application.StartupPath + "\\mainDB.sdf");
     SqlCeCommand sqlCmd = new SqlCeCommand("SELECT count(*) FROM Accounts WHERE (username = @user AND password = @pass)", sqlCnn);
     sqlCmd.Parameters.Add("@user", textBox1.Text);
     sqlCmd.Parameters.Add("@pass", textBox2.Text);
     sqlCnn.Open();
     int recordCount = (int)sqlCmd.ExecuteScalar();
     
    if (recordCount > 0)
    {
    //dostuff
    }
