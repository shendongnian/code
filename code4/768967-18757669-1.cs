    var file = @"C:\myOutput.csv";
    using (var stream = File.CreateText(file))
    {
        for (int i = 0; i < reader.Count(); i++)
        {
            string first = reader[i].ToString();
            string second = image.ToString();
            string csvRow = string.Format("{0},{1}", first, image);
            stream.WriteLine(csvRow);
        }
    }
