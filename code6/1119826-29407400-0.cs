    var files = from file in Directory.EnumerateFiles(@"C:\Users\K\Desktop\New folder", "*.txt", SearchOption.AllDirectories)
                from line in File.ReadLines(file)
                select new
                {
                    File = file,
                    Line = line
                };
    
    foreach (var f in files)
    {
        Console.WriteLine("{0}\t{1}", f.File, f.Line);
        string[] Lines = File.ReadAllLines(f.File);
        bool startFound = false;
    
        using (MySqlConnection con = new MySqlConnection(@"server=localhost;database=test;uid=root;pwd=pw;"))
        {
            con.Open();
            foreach (string line in Lines)
            {
                if (!startFound) 
                {
                    if (Lines.Contains("[Start]"))
                    {
                        startFound = true;
                    }
                    else
                    {
                        continue;
                    }
                }                        
    
                string[] readLineSplit = line.Split('|');
    
                if(readLineSplit.Length > 1)
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Products(Product_Name, Product_Price, QTY) VALUES (@Product_Name, @Product_Price, @QTY)", con);
                    cmd.Parameters.AddWithValue("@Product_Name", readLineSplit[0].ToString());
                    cmd.Parameters.AddWithValue("@Product_Price", readLineSplit [1].ToString()); 
                    cmd.Parameters.AddWithValue("@QTY", readLineSplit[2]);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
