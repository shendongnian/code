As you have the string [missionMMap] to break up the parts in the file something like this should work out.
    using(StreamReader readFile = new StreamReader(path))
    {
        string line;
        bool isMissionMMap = false;
        while((line = readFile.ReadLine()) != null)
        {
            if(!string.IsNullOrEmpty(line))
            {
                if(!isMissionMMap && line.StartsWith("[missionMMap]")) // Short circuit early if the missionMMap portion has already been entered
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
Edit: You can replace the last if/else statement with a pretty funky ternary operator if you want. I'm not going to recommend it because it isn't that readable, I am just adding it because I find it cool.
    (isMissionMMap ? missionMMap : MMap).Add(line);
