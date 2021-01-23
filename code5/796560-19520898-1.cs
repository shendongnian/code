    string[] lines = System.IO.File.ReadAllLines(@"C:\myCSV.csv");
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\myCSV2.csv"))
        {
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                file.WriteLine(string.Format("{0} {1},{2},{3}",values[0],values[1],values[2],values[3]));
            }
        }
