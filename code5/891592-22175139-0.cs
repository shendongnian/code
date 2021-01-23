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
            return friendMasterList;
        }
