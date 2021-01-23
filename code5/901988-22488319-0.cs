     string data = "Car|cBlue,Mazda~Model|m3";
                List<string> delimiters = new List<string>();
                delimiters.Add("|c");//Change this to user input
                delimiters.Add("|m");//change this to user input
    
                string[] parts = data.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in parts)
                {
                    Console.WriteLine(item);   
                }
