    private void button1_Click(object sender, EventArgs e)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        string conn = "Data Source=" + (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)) + "\\AppDatabase1.sdf;Persist Security Info=False";
        SqlCeConnection connection = new SqlCeConnection(conn);
        int z = 1;
        string name = "stack";
        string surname = "overflow";
        progressBar1.Maximum = 2001;
        
	String query = "Insert into test (id,name,surname) values (0, name, surname)"
	while (z<2000)
        {
		query = query + ", ("+z+", "+name+", "+surname+")"
		z++;
                progressBar1.Value = z;
	    }
         try
            {
                connection.Open();
                SqlCeCommand cmd = new SqlCeCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                z++;
                progressBar1.Value = z;
             }
          catch (SqlCeException)
             {
                 MessageBox.Show("!!!","exception");
             }
          finally
             {
             }
            
        stopwatch.Stop();
        MessageBox.Show("Time: {0}" + stopwatch.Elapsed);
        connection.Close();
    }
