    public static void DirSearch(string sDir)
        {
            
            
            string ExtractedTXTBlocks = FINAL_PATH + "\\" + "Extracted TXT Blocks";
            System.IO.Directory.CreateDirectory(ExtractedTXTBlocks);
            try
            {
                
                    foreach (string f in Directory.GetFiles(sDir, "*.TXT", SearchOption.AllDirectories))
                    {
                        string[] filelines = File.ReadAllLines(f);
                        string line = "";
                        string sBuilder = "";
                        int i = 1;
                        string temp = "";
                        
                        string Fname = f.Substring(f.LastIndexOf("\\"), (f.Length - f.LastIndexOf("\\"))).Replace("\\","");
                        string Dname = Path.GetDirectoryName(f);
                        Dname = Dname.Substring(Dname.LastIndexOf("\\"), Dname.Length - Dname.LastIndexOf("\\")).Replace("\\", "");
                        
                        StreamWriter sW = new StreamWriter(ExtractedTXTBlocks + "\\" + Dname + "-" + Fname, true);
                        foreach (string item in filelines)
                        {
                            i++;
                            line = item;
                            line = (line.Replace("CMD", "")).Trim();
                            line = (line.Replace("0x", "")).Trim();
                            line = (line.Replace("0X", "")).Trim();
                            line = (line.Replace("DI", "")).Trim();
                            line = (line.Replace("SW", "")).Trim();
                            line = (line.Replace("LO 0", "")).Trim();
                            line = (line.Replace("LI", "")).Trim();
                            line = (line.Replace("LE 0", "")).Trim();
                            line = (line.Replace("REM", "")).Trim();
                            line = (line.Replace("$", "")).Trim();
                            line = (line.Replace("LO", "")).Trim();
                            line = (line.Replace("DO", "")).Trim();
                            line = (line.Replace(" ", "")).Trim();
                            if (line.StartsWith("1234") || line.StartsWith("1233"))
                            {
                                temp = line.Substring(8, line.Length - 8);
                                int number = int.Parse(temp);
                                temp = line.Substring(8, line.Length - 8).Replace(line.Substring(8, line.Length - 8), number.ToString("x").ToUpper());
                                line = line.Remove(8, line.Length - 8);
                                line += temp;
                                sBuilder = line;
                            }
                            else if (line.StartsWith("1235") || line.StartsWith("1255"))
                            {
                                temp = line.Substring(8, line.Length - 8);
                                int number = int.Parse(temp);                                
                                temp = line.Substring(8, line.Length - 8).Replace(line.Substring(8, line.Length - 8),number.ToString("x").ToUpper());
                                line = line.Remove(8, line.Length - 8);
                                line += temp;
                                sBuilder = line;
                            }
                            else if (line.Equals("Success"))
                            {
                                sW.WriteLine(sBuilder);                                
                                sBuilder = "";
                            }                            
                            else
                            {
                                if (!line.Equals(""))
                                {
                                    sBuilder += line;
                                }
                            }
                            
                        }
                        sW.Close();
                        
                    }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
