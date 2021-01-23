    public async Task TestMultiMapArbitraryWithSplitAsync()
        {
            const string sql = @"select 1 as id, 'abc' as name, 2 as id, 'def' as name";
            var productQuery = await connection.QueryAsync<Product>(sql, new[] { typeof(Product), typeof(Category) }, (objects) => {
                var prod = (Product)objects[0];
                prod.Category = (Category)objects[1];
                return prod;
            });
            var product = productQuery.First();
            // assertions
            product.Id.IsEqualTo(1);
            product.Name.IsEqualTo("abc");
            product.Category.Id.IsEqualTo(2);
            product.Category.Name.IsEqualTo("def");
        }
