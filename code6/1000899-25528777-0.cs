    public void readInData()
    {
        rtbData.Clear();
        rtbData.AppendText("...Retrieving Data From Database...");
        await readDatabase();
    }
    async Task readDatabase()
    {
        reader = dataCommand.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                numbers.Add(reader.GetInt32(0).ToString());
                names.Add(reader.GetString(1));
                weights.Add(reader.GetDouble(2).ToString());
                statuses.Add(reader.GetString(3));
                times.Add(reader.GetDateTime(4).ToString());
                counter++;
            }
        }
        connection.Close();
    }
