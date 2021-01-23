            List<List<string>> dataList = new List<List<string>>();
            string filename = @"C:\CSV\test.csv";
            using (StreamReader sr = new StreamReader(filename))
            {
                string fileContent = sr.ReadToEnd();
                
                foreach (string line in fileContent.Split(new string[] {Environment.NewLine},StringSplitOptions.RemoveEmptyEntries))
                {
                    List<string> data = new List<string>();
                    foreach (string field in line.Split(';'))
                    {
                        data.Add(field);
                    }
                    try
                    {
                        string resultIBAN = client.BBANtoIBAN(data[0]);
                        if (resultIBAN != string.Empty)
                        {
                            data.Add(resultIBAN);
                        }
                        else
                        {
                            data.Add("Accountnumber is not correct.");
                        }
                    }
                    catch (Exception msg)
                    {
                        Console.WriteLine(msg);
                    }
                    dataList.Add(data);
                }
