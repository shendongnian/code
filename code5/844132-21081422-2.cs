     public void getDiff(String FirstFile, string SecondFile, string ResultFile)
            {
                try
                {
                    //check if file exits....
                    if (!File.Exists(FirstFile)) { return; }
                    if (!File.Exists(SecondFile)) { return; }
    
                    //Keep the result String..
                    StringBuilder ResultBuilder = new StringBuilder();
    
                    //Get the List of default file.
                    List<DefaultFileStructure> DefaultList = GetFileStructure(FirstFile, DEFAULT_KN);
    
                    //Get the List of test file.
                    List<DefaultFileStructure> TestList = GetFileStructure(SecondFile, TEST_KN);
    
                   
                    //Get the diff and save in StringBuilder.
                    foreach (DefaultFileStructure defFile in DefaultList)
                    {
                        bool checkALL = false;
                        foreach (DefaultFileStructure testFile in TestList)
                        {
                            //Compare the file for diff.
                            if (defFile.FileId == testFile.FileId)
                            {
                                checkALL = false;
                                ResultBuilder.AppendLine(String.Format("result: {0} FMR_DIFF: {1} FNMR_DIFF: {2} SCORE_DIFF: {3}", defFile.FileId, defFile.FMR - testFile.FMR, defFile.FNMR - testFile.FNMR, defFile.Score - testFile.Score));
                                break;
                            }
                            else
                            {
                                checkALL = true;                      
                            }                        
                        }
                        if (checkALL == true)
                        {
                            ResultBuilder.AppendLine(String.Format("result: {0} FMR_DIFF: {1} FNMR_DIFF: {2} SCORE_DIFF: {3}", defFile.FileId, "N/A", "N/A", "N/A"));
                            
                        }
                    }
    
                    //File processing completed.
                    using (StreamWriter outfile = new StreamWriter(ResultFile))
                    {
                        outfile.Write(ResultBuilder.ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
