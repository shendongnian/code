    public void FixTheFiles(String startFolderPath)
            {
                foreach (String dirName in Directory.GetDirectories(startFolderPath))
                {
                    FixTheFiles(dirName);
                }
                foreach (String fileName in Directory.GetFiles(startFolderPath))
                {
                    FileInfo fi = new FileInfo(fileName);
                    if (fi.Extension.Equals("MP3"))
                    {
                        String fileContents = "";
                        using (StreamReader sr = new StreamReader(File.Open(fileName.Replace(".mp3",".txt"),FileMode.Open)))
                        {
                            String currentLine = sr.ReadLine();
                            if (currentLine.StartsWith("#MP3:"))
                            {
                                currentLine = "#MP3:" + fileName.Substring(fileName.LastIndexOf('\\')+1);
                            }
                            fileContents += currentLine;
                        }
                        using (StreamWriter sw = new StreamWriter(File.Open(fileName.Replace(".mp3",".txt"),FileMode.Open)))
                        {
                            sw.Write(fileContents);
                        }
                    }
                }
            }
