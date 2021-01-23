    private void button10_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"..."; 
    
        //Query all entries between 08:15 and 09:00 today
        DateTime startTime = DateTime.Now.Date.AddHours(8).AddMinutes(15);
        DateTime endTime = startTime.AddMinutes(45);
    
        // I use "using" to make sure command and data adapter are disposed of automatically
        // I use a separate command so I can add the parameters more easily.
        using (SqlCommand cmd = new SqlCommand("SELECT ... WHERE .. AND CHECKINOUT.CHECKTIME BETWEEN @startTime and @endTime ORDER BY CHECKTIME DESC ", con))
        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        {
            // Pass in the two parameters to the query (note: I don't have to take care
            // of any formatting here - aren't parameterized queries a treat? :-)
            cmd.Parameters.AddWithValue("@startTime", startTime);
            cmd.Parameters.AddWithValue("@endTime", endTime);
    
            // Keep doing what you did before
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
