    var files = from file in Directory.EnumerateFiles(@"C:\Users\K\Desktop\New folder", "*.txt", SearchOption.AllDirectories)
                from line in File.ReadLines(file)
                select new
                {
                    File = file,
                    Line = line
                };
    using (MySqlConnection con = new MySqlConnection(@"server=localhost;database=test;uid=root;pwd=pw;"))
    {
        foreach (var f in files)
        {
            Console.WriteLine("{0}\t{1}", f.File, f.Line);
            string[] Lines = File.ReadAllLines(f.File);
            bool processRecord = false;
            con.Open();
            foreach (string line in Lines)
            {
                if (!processRecord)
                {
                    if (Lines.Contains("[Start]"))
                    {
                        processRecord = true;
                        continue;
                    }
                }
                if (processRecord)
                {
                    string[] readLineSplit = line.Split('|');
                    if (readLineSplit.Length > 1)
                    {
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO Products(Product_Name, Product_Price, QTY) VALUES (@Product_Name, @Product_Price, @QTY)", con);
                        cmd.Parameters.AddWithValue("@Product_Name", readLineSplit[0]);
                        cmd.Parameters.AddWithValue("@Product_Price", readLineSplit[1]);
                        cmd.Parameters.AddWithValue("@QTY", readLineSplit[2]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
