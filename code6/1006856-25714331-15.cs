    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    namespace WPFPlayground.ViewModel
    {
        public class DesignProductsViewModel : ProductsViewModel
        {
            public DesignProductsViewModel()
            {
                var random = new Random();
                Products = new ObservableCollection<ProductViewModel>(Enumerable.Range(1, 5).Select(i => new ProductViewModel
                {
                    Name = String.Format(@"Product {0}", i),
                    IsDefective = (random.Next(1, 100) < 50)
                }));
            }
        }
    }
