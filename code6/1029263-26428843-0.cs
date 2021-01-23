    class CSVOrderById
    {
        class IgaAdKey: IComparable
        {
            public int ResourceId { get; set; }
            public int EditionId { get; set; }
            public int LocationId { get; set; }
            //required if added to Dictionary, not the correct implementation though
            public int CompareTo(object obj) 
            {
                IgaAdKey key = obj as IgaAdKey;
                if (key == null)
                    return -1;
                else
                    return (ResourceId + EditionId + LocationId).CompareTo(key.ResourceId + key.EditionId + key.LocationId);                
            }
        }
        class IgaEntry
        {
            public int mClickCount { get; set; }
            public int mViewCount { get; set; }
        }
        public static void Test()
        {
            var enteries = new SortedDictionary<IgaAdKey, IgaEntry>();
            
            enteries.Add(new IgaAdKey(){ ResourceId = 123, EditionId = 12313, LocationId = 2}, new IgaEntry(){ mClickCount = 2, mViewCount = 10});
            enteries.Add(new IgaAdKey(){ ResourceId = 123, EditionId = 12332, LocationId = 2}, new IgaEntry(){ mClickCount = 2, mViewCount = 10});
            enteries.Add(new IgaAdKey(){ ResourceId = 234, EditionId = 23413, LocationId = 1}, new IgaEntry(){ mClickCount = 2, mViewCount = 10});
            //enteries.Add(new IgaAdKey(){ ResourceId = 234, EditionId = 23455, LocationId = 1}, new IgaEntry(){ mClickCount = 2, mViewCount = 10});
            enteries.Add(new IgaAdKey(){ ResourceId = 789, EditionId = 78922, LocationId = 2}, new IgaEntry(){ mClickCount = 2, mViewCount = 10});
            //enteries.Add(new IgaAdKey(){ ResourceId = 789, EditionId = 78999, LocationId = 2}, new IgaEntry(){ mClickCount = 2, mViewCount = 10});
            var list = enteries.ToList(); //inorder to call FindAll()
            var dic = new Dictionary<int, List<KeyValuePair<IgaAdKey, IgaEntry>>>();
            var streamWriter = new StreamWriter("a.csv");
            //first find all ResourceId's, 
            HashSet<int> currResourcesId = new HashSet<int>();
            foreach (var pair in list)
            {
                currResourcesId.Add(pair.Key.ResourceId); //result: 3 unique ResourceId's
            }
            int maxCount = 0; 
            foreach (int resourceId in currResourcesId)
            {
                List<KeyValuePair<IgaAdKey, IgaEntry>> sortedByResourcesId = list.FindAll(pair => pair.Key.ResourceId == resourceId);
                dic.Add(resourceId, sortedByResourcesId);
                if (sortedByResourcesId.Count > maxCount)
                    maxCount = sortedByResourcesId.Count; //result: maxCount = 2 
            }
            //so we write 2 rows
            for (int run = 0; run < maxCount; run++) 
            {
                streamWriter.Write(System.DateTime.Now.ToString("yyyyMMdd") + ",");
                foreach (int resourceId in currResourcesId)
                {
                    if (dic[resourceId].Count > run)
                    {
                        streamWriter.Write(dic[resourceId][run].Key.LocationId + ",");
                        streamWriter.Write(dic[resourceId][run].Key.EditionId + ",");
                        streamWriter.Write(dic[resourceId][run].Value.mClickCount + ",");
                        streamWriter.Write(dic[resourceId][run].Value.mViewCount + ",");
                        streamWriter.Write(",");
                    }
                    else
                    {
                        streamWriter.Write(",,,,,");
                    }
                }
                if (run < maxCount)
                    streamWriter.WriteLine();
            }
            
            streamWriter.Close();        
        }
    }
