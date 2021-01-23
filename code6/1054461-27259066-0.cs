    using(StreamReader readFile = new StreamReader(path))
    {
        string line;
        bool isMissionMMap = false;
        while((line = readFile.ReadLine()) != null)
        {
            if(!string.IsNullOrEmpty(line))
            {
                if(line == "[missionMMap]")
                {
                    isMissionMMap = true;
                    continue; //Ignore this line of text as it is more than likely useless
                }
                if(isMissionMMap)
                {
                    missionMMap.Add(line);
                }
                else
                {
                    MMap.Add(line)
                }
            }
        }
    }
