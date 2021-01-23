        public void Example()
        {
            _productList.Clear();
            _productList.AddRange(_productHandler.ReadAllProducts());
            // displaying
            foreach (var product in _productList)
                Trace.WriteLine(string.Format("code: {0}, description: {1}, quantity: {2}", product.Code, product.Description, product.Quantity);
            // updating
            var selectedProduct = _productList.FirstOrDefault(item => item.Code == 15);
            if(selectedProduct!= null)
            {
                selectedProduct.Quantity = 50;
                _productHandler.UpdateProduct(selectedProduct);
            }
            // deleting
            _productHandler.DeleteProducts(_productList.Where(item => item.Quantity < 5));
        }
