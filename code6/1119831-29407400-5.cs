    var files = Directory.EnumerateFiles(@"C:\Users\K\Desktop\New folder", "*.txt", SearchOption.AllDirectories);
    using (MySqlConnection con = new MySqlConnection(@"server=localhost;database=test;uid=root;pwd=pw;"))
    {
        con.Open(); // new Position of con.Open()
        foreach (var f in files)
        {
            Console.WriteLine(f);
            string[] Lines = File.ReadAllLines(f);
            bool processRecord = false;
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
                if (Lines.Contains("[End]"))
                {
                    processRecord = false;
                    continue;
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
