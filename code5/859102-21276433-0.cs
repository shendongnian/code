    using (StreamReader rdr = new StreamReader(@"C:\test2\test.csv"))
                        {
                            string description = "SAP_Eingang";
                            string separator = "#_#";
                            DirectoryInfo di = new DirectoryInfo(@"c:\test\");
                            FileInfo[] files = di.GetFiles("*.pdf");
                            foreach (FileInfo fi in files)
                            {
                                string[] columns = new string[4];
                                columns[0] = description;
                                columns[1] = fi.CreationTime.ToString("yyyy.MM.dd hh:mm:ss");
                                columns[2] = fi.Name.Substring(0, 20);
                                columns[3] = fi.Name;
                                string line = String.Join(separator,columns);
                                rdr.Close();
                                File.WriteAllLines(@"C:\test2\test.csv", columns);
                                
                            }
                        }
