    class DatabaseDescriptorComparer : IEqualityComparer<DatabaseDescriptor>
    {
        public bool Equals(DatabaseDescriptor x, DatabaseDescriptor y)
        {
            return
                x.Name == y.Name;
        }
     
        public int GetHashCode(DatabaseDescriptor obj)
        {
            return obj.Name.GetHashCode();
        }
    }
