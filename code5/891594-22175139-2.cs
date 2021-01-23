        private static Dictionary<string, List<string>> ProcessData(Dictionary<string, List<string>> data)
        {
            var processedData = new Dictionary<string, List<string>>();
            var masterList = new List<string>();
            foreach (var value in data.Keys)
            {
                if (!masterList.Contains(value))
                {
                    var friendList = FindFriends(data, value);
                    masterList.AddRange(friendList);
                    processedData.Add(value, friendList);
                }
            }
            return processedData;
        }
        private static List<string> FindFriends(Dictionary<string, List<string>> data,string source)
        {
            var friendMasterList = new List<string>();
            var friendQueue = new Queue<string>();
            if (data.ContainsKey(source))
            { 
                foreach (var value in data[source])
                {
                    friendQueue.Enqueue(value);
                }
                while (friendQueue.Count > 0)
                {
                    var value = friendQueue.Dequeue();
                    if (!friendMasterList.Contains(value))
                        friendMasterList.Add(value);
                    
                    if (data.ContainsKey(value))
                    {
                        foreach (var value2 in data[value])
                        {
                            if (!friendMasterList.Contains(value2))
                                friendQueue.Enqueue(value2);
                        }
                    }
                } 
            }
            if (friendMasterList.Contains(source))
                friendMasterList.Remove(source);
            return friendMasterList;
        }
