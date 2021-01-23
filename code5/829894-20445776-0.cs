    public class GroupManager
    {
        private readonly GroupStore groups = new GroupStore();
        public GroupStore Groups { get { return this.groups; } }
        public void Add(string groupName, string connectionSring)
        {
            groups.Add(groupName, connectionSring);
        }
    }
    public class GroupStore : IEnumerable<string>
    {
        private readonly ConcurrentDictionary<string, HashSet<string>> groupStore = new ConcurrentDictionary<string, HashSet<string>>();
        public IEnumerable<string> this[string index] { get { return this.groupStore[index]; } }
        public IEnumerator<string> GetEnumerator()
        {
            return groupStore.Keys.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public void Add(string groupName, string connectionSring)
        {
            groupStore.AddOrUpdate(
                groupName,
                new HashSet<string>(new string[1] { connectionSring }),
                (conn, list) => { list.Add(conn); return list; });
        }
    }
