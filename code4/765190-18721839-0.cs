    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            // ... other properties ...
            HasMany(x => x.Name) // <-- this line is the problem
                .Inverse()
                .Cascade.All();
            // ... other properties ...
        }
    }
