    List<UserData> data = new List<UserData>();
    try
    {        
        if (openFileDialog1.FileName != string.Empty)
        {
            using (StringReader reader = new StringReader(openFileDialog1.FileName))
            {
                int count = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    UserData d = new UserData();
                    string[] parts = line.Split(':');
                    d.UserName = parts[0].Trim();
                    d.Password = parts[1].Trim();
                    data.Add(d);
                }
                // At the loop end you could use the List<UserData> like a normal array
                foreach(UserData ud in data)
                {
                    Console.WriteLine("User=" + dd.UserName + " with password=" + dd.Password);
                }
            }
        }
    }
