    // Write the data here..
    foreach (DataRow p in data.Rows)
    {
        // Write a single CSV line direct from the database record
        tw.WriteLine(string.Format("\"{0}\", \"{1}\", \"{2}\", \"{3}\"", p.Field<double>("ID"), p.Field<string>("Track Name"), p.Field<string>("Artist Name"), p.Field<double>("NoOfPlays"));
    }
