                string inputDirectory = "";
                private void DoSomething(string inputDirectory)
                {
                    try
                    {
                        if(String.IsNullOrEmpty(inputDirectory))
                        throw new ArgumentNullException();
                        Directory.CreateDirectory(inputDirectory)
                    }
                    catch (ArgumentNullException e)
                    {
                        Log.Error("program failed because the directory supplied was empty", e.Message);
                    }
                }
