    static Resource {
        public String Name { get; set; }
        public String UnitMass { get; set; }
    }
    static Bucket {
        public Resource FilledWith { get; set; }
        public Resource Quantity { get; set; }
        public float TotalMass {
          get { return FilledWith.UnitMass * Quantity; }
        }
    }
    static class ResourceTable {
        public Resource Iron =
          new Resource { Name = "Iron", UnitMass = 1};
        public Resource Feather =
          new Resource { Name = "Feather", UnitMass = 0.1};
    }
    var aBucket = new Bucket {
        FilledWith = ResourceTable.Iron,
        Quantity = 100
    };
    
