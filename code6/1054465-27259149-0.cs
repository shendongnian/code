    List<string> MMap = new List<string>();
    List<string> missionMMap = new List<string>();
    public void readFile(string path)
    {
        try
        {
            MMap.Clear();
            // This technically doesn't need to be initialized here, but better safe...
            bool readingMMap = true;
            using (StreamReader readFile = new StreamReader(path))
            {
                string line;
                while ((line = readFile.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        if(line.StartsWith("[MMap]"))
                        {
                            readingMMap = true;
                        }
                        else if(line.StartsWith("[missionMMap]"))
                        {
                            readingMMap = false;
                        }
                        else
                        {
                            if(readingMMap)
                                MMap.Add(line);
                            else
                                missionMap.Add(line);
                        }
                    }
                }
            }
        }
        catch (Exception e) { MessageBox.Show(e.Message, "Error!"); }
    }
