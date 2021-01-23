            NopEngine _engine;
            /// <summary>
            /// Returns IPagedList(Product) filled with all products, without selection
            /// </summary>
            /// <returns></returns>
            public IPagedList<Product> GetAllProducts()
            {
                _engine = new NopEngine();
                var _allService = _engine.Resolve<IProductService>();
                return _allService.SearchProducts();
            }
