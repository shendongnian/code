    public class Variable
    {
        // Properties.
        public string Database { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Dimensions { get; set; }
        public int Order { get; set; }
        public int[] Size { get; set; }
        public double[] Value { get; set; }
    
        // Default constructor.
        public Variable()
        {
        }
    
        // Constructor.
        public Y_Variable(string db, string nam, string typ, int dim, int ord, 
            int[] siz, double[] val)
        {
            this.Database = db;
            this.Name = nam;
            this.Type = typ;
            this.Dimensions = dim;
            this.Order = ord;
            this.Size = siz;
            this.Value = val;
        }
    }
