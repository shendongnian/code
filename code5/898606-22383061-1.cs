    public class Order()
    {
        public int id;
        // Cached total weight.
        private int _totalProductsWeight;
        // When true, must compute weight before returning
        private bool _dirtyFlag;
        public int TotalProductsWeight 
        { 
           get
           {
               if (_dirtyFlag)
               {
                   _totalProductsWeight = ComputeWeight();
                   _dirtyFlag = false;
               }
               return _totalProductsWeight;
           }
        }
        public IList<Products> prodList = new List<Products>() { get; private set;}
        public void AddProducts(IList<Products> prod)
        {
            prodList.AddRange(prod);
            // Mark the weight as dirty.
            _dirtyFlag = true;
        }
    }
