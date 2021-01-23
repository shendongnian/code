    static List<Song> RemoveDuplicates(IList<Song> originalList)
            {
                HashSet<string> set = new HashSet<string>();
                List<Song> cleanedList = new List<Song>(originalList.Count);
    
                foreach (Song obj in originalList)
                {
                    if (!set.Contains(obj.path))
                    {
                        set.Add(obj.path);
                        cleanedList.Add(obj);
                    }
                }
                return cleanedList;
            }
