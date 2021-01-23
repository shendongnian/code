    using System.Collections.ObjectModel;
    public class ConnectionMapping<T>
    {
        private class Mapping
        {
            public T Key;
            public HashSet<string> Items;
        }
        private class ConnectionsCollection : KeyedCollection<T, Mapping>
        {
            protected override T GetKeyForItem(Mapping item)
            {
                return item.Key;
            }
        }
        private readonly ConnectionsCollection _connections = new ConnectionsCollection();
        /// Implementation of various collection methods, Add, RemoveAt, etc.
        public void RemoveAt(int index)
        {
            lock(_connections)
            {
                _connections.RemoveAt(index);
            }
        }
    }
