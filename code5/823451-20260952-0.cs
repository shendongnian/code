    private void ConvertToIBANAccount(string fileName,string outFileName)
    {
        using (var client = new WebService.BANBICSoapClient("IBANBICSoap"))
            {
                StreamReader sr = new StreamReader(fileName);
                StreamWriter sw = new StreamWriter(outFileName);
                Console.WriteLine("Bezig met converteren....");
                while (sr.Peek() >= 0) 
                {
                string line = sr.ReadLine(); 
                    try
                    {
                        string[] rowsArray = line.Split(';');
                        line = string.Empty;
                        string account = rowsArray[0];
                        string relationID = rowsArray[1];
                        string resultIBAN = client.BBANtoIBAN(account);
                        string resultBIC = client.BBANtoBIC(account);
                        if (resultIBAN != string.Empty && resultBIC != string.Empty)
                        {
                            line = account + ";" + resultIBAN +";" + resultBIC + ";" + relationID;
                        }
                        else
                        {
                            line = account + ";" + "0" + ";" + "0" + ";" + relationID;
                        }
                    }
                    catch (Exception msg)
                    {
                        Console.WriteLine(msg);
                    }
                sw.WriteLine(line) ;
                }
                sr.Close();
                sw.Close();
            }
            Console.WriteLine("Conversie succesvol");
            Console.ReadLine();
        }
    }
