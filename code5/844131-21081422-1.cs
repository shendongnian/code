        private List<DefaultFileStructure> GetFileStructure(string filePath, string keyName)
                {
                    List<DefaultFileStructure> _defaultFileStructure = new List<DefaultFileStructure>();
        
                    if(!File.Exists(filePath))
                    {
                        Console.WriteLine("Error in loading the file");               
                    }else{
                        string[] readText = File.ReadAllLines(filePath);
                        foreach (string s in readText)
                        {
                            _defaultFileStructure.Add(ParseLine(s, keyName));                    
                        }
                    }
        
                    return _defaultFileStructure;
                }
    
    private DefaultFileStructure ParseLine(string Line, string Keyname)
            {
                DefaultFileStructure _dFileStruc = new DefaultFileStructure();
    
                string[] groups = Line.Split(new[] { ' ', ' ' },StringSplitOptions.RemoveEmptyEntries);
    
                /* -- Format Strucure, if the log provide same format always..
                   Can also implement Expando concepts of C# 5.0 ***
                    0[tv_rocscores_DeDeP005M3TSub.csv]
                    1[FMR:]
                    2[0.0009]
                    3[FNMR:]
                    4[0.023809524]
                    5[SCORE:]
                    6[-4]
                    7[Conformity:]
                    8[True]
                 */
    
                _dFileStruc.FileId = groups[0].Replace(Keyname, "");
                _dFileStruc.FMR = decimal.Parse(groups[2]);
                _dFileStruc.FNMR = decimal.Parse(groups[4]);
                _dFileStruc.Score = int.Parse(groups[6]);
                _dFileStruc.Conformity = bool.Parse(groups[8]);
    
                return _dFileStruc;
            }
