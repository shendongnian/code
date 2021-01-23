    using (var sr = new StreamReader(file))
    {
        string fileLine;
        while ((fileLine = sr.ReadLine()) != null)
        {
            foreach (string piece in fileLine.Split(','))
            {
                listView1.Items.Add(piece);
            }
        }
    }
