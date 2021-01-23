    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BetfairDatabaseMDI.embeddedResources.Competition.csv"))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            while (!reader.EndOfStream)
                            {
                                string result = reader.ReadLine();
                                result = "'" + result + "'";
                                result = result.Replace(",", "','");
    
                                MySqlCommand("INSERT INTO Competition " +
                                            "VALUES (" + result + ")");
                            }
                        }
                    }
