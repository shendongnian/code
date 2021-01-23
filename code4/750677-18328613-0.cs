            NopEngine _engine;
            /// <summary>
            /// Returns IPagedList(Product) filled with all products from selected CategoryId
            /// </summary>
            /// <param name="Categoryid"></param>
            /// <returns></returns>
            public IPagedList<Product> GetAllProductsFromCategory(int Categoryid)
            {
                _engine = new NopEngine();
                var _productService = _engine.Resolve<IProductService>();
                List<int> CategoryIds = new List<int>();
                CategoryIds.Add(Categoryid);
                return _productService.SearchProducts(categoryIds: CategoryIds);
            }
