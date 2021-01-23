    class DatabaseDescriptorNameComparer : IEqualityComparer<DatabaseDescriptor>
    {
        public static readonly DatabaseDescriptorNameComparer Instance =
            new DatabaseDescriptorNameComparer();
        private DatabaseDescriptorNameComparer()
        {
        }
        public bool Equals(DatabaseDescriptor x, DatabaseDescriptor y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(DatabaseDescriptor obj)
        {
            return obj.Name.GetHashCode();
        }
    }
