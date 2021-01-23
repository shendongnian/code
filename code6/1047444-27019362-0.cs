    public class Group
    {
        public readonly object Key;
        public readonly IEnumerable<Group> Groups;
        public readonly IEnumerable<DataRow> Drs;
    
        public Group(object key, IEnumerable<DataRow> source, List<string> columnList)
        {
            Key = key;
    
            if (columnList.Count == 0)
                Drs = source;
            else
            {
                string firstColumn = columnList.First();
                List<string> restOfColumns = columnList.Skip(1).ToList();
    
                Groups = source.GroupBy(dr => dr[firstColumn])
                               .Select(g => CreateGroup(g.Key, g, restOfColumns));    
            }
        }
    
        protected virtual Group CreateGroup(object key, IEnumerable<DataRow> source, List<string> columnList)
        {
            return new Group(key, source, columnList)
        }
    }
