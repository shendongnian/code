    var productA = Task.Factory.StartNew<IEnumerable<Product>>(() => _productRepository.GetProductsA());
    var productB = Task.Factory.StartNew<IEnumerable<Product>>(() => _productRepository.GetProductsB());
    Task.WaitAll(produtosTotvs, produtosLive);
    
    productsA.Result.CompareBeta<Produto>(productsB.Result, new List<string> { "Cod" }, "Key");
