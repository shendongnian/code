    void _populateWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        using(var conn = new SqlConnection(ClassGlobal.ConnectionString
        using (SqlCommand sqlCommand = new SqlCommand(".....", conn))
        {
            conn.Open();
            // Here goes some code that populate the current form
        }
    }
