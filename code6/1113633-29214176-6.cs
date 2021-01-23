    public class FooGroup
    {
        public List<FooItem> Items { get; private set; }
        public int ID { get; private set; }
    
        public FooGroup(int ndx)
        {
            Items = new List<FooItem>();
            ID = ndx;
        }
    
        public void Add(FooItem f)
        {
            Items.Add(f);
        }
    
        public void AddRange(FooItem[] f)
        {
            foreach (FooItem ff in f)
            {
                this.Add(ff);
            }
        }
    
        public int Count()
        {
            return Items.Count;
        }
    
        public int TotalWeight()
        {
            return Items.Sum(w => w.Weight);
        }
    
        public override string ToString()
        {
            return String.Format("ID: {0} Wt: {1}", 
                ID.ToString(), this.TotalWeight().ToString());
        }  
    }
