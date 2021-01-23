    Comparer<String> GetMaterialComparer()
    {
       if(condition1...)
          return new materialComparer1();
       if(condition2...)
          return new materialComparer2();
       etc...
    }
    class materialComparer1 : materialComparer
    {
        static Dictionary<String, int> specificOrder = new Dictionary<String, int>
                    {
                        {"matOne", 2},
                        {"matTwo", 1},
                        {"matThree", 3}
                    };
        protected override Dictionary<string, int> order { get { return specificOrder; } }
    }
    abstract class materialComparer : Comparer<String>
    {            
        protected abstract Dictionary<String, int> order{get;}
        public override int Compare(string x, string y)
        {
            return order[x].CompareTo(order[y]);
        }
    }
