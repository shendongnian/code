    using (var cmd = new SqlCommand("SELECT logo FROM company WHERE id = 1", spojeni))
    using (var dataAdapter = new SqlDataAdapter(cmd))
    {
        var dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count == 1)
        {
            // generate temp file destination
            dataImage = System.IO.Path.GetTempFileName() + ".jpg"; // use whatever extension you expect the file to be in
            File.WriteAllBytes(dataImage, (byte[])dataSet.Tables[0].Rows[0]["logo"]); // save image to disk
        }
   
    }
