     public static string ChangeCardNumber(string FilePath, string txtFileName)
            {
                string NewPath = "";
                string lineOfText;
                string NewTextFile = "";
                NewPath = FilePatharr[0] + "\\temp_" + txtFileName;
    
                using (var filestream = new FileStream(FilePath,
                                     FileMode.Open,
                                     FileAccess.Read,
                                     FileShare.ReadWrite))
                {
                    var file = new StreamReader(filestream, Encoding.UTF8, true, 128);
                    System.IO.File.Create(NewPath).Close();
                    int res = 0;
                    while ((lineOfText = file.ReadLine()) != null)
                    {
                        res++;
    
                        if (!lineOfText.Contains("EOF"))
                        {
                            NewTextFile += lineOfText.Substring(0, 124) + "************" +
                            lineOfText.Substring(136, lineOfText.Length - 136);
                            NewTextFile += Environment.NewLine;
                        }
                        if (res % 200 == 0 || lineOfText.Contains("EOF"))//check if endline and if in NewTextFile 200lines
                        {
                            System.IO.File.AppendAllText(NewPath, NewTextFile);
                            NewTextFile = "";
                        }
                    }
    
                }
    
    
    
                return NewPath;
    
            }
