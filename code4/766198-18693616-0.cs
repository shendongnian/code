        public int GetCount(List<int> source, List<int> innerList)
        {
            source = source.OrderBy(i => i).ToList();
            innerList = innerList.OrderBy(i => i).ToList();
            int count = 0;
            for (var i = 0; i <= source.Count - innerList.Count; i++)
            {
                if (source.Skip(i).Take(innerList.Count).SequenceEqual(innerList))
                {
                    count++;
                }
            }
            return count;
        }
