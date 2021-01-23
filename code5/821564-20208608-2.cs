       Dictionary<string, string> dicData = new Dictionary<string, string>();
        private void processDirectory(string startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                DirectoryInfo dr = new DirectoryInfo(directory);
                {
                    if (!dicData.ContainsKey(dr.Parent.Name))
                        dicData.Add(dr.Parent.Name, dr.Name);
                    else
                        dicData[dr.Parent.Name] += "," + dr.Name;
                }
                processDirectory(directory);
            }
        }
    A --> B , C
    B --> X --> Y -->Z
    C --> P --> Q
