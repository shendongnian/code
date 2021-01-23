    List<List<DateTime>> listOfDateTimes = new List<List<DateTime>>();           
    for(int xx=0;xx<40;xx++)
    {
        listOfDateTimes.Add(new List<DateTime>());
        for(int yy=0;yy<numList[xx];yy++)
        {
            listOfDateTimes[xx].Add(File.GetLastWriteTime(ultimateList[xx][yy]));
        }
    }
