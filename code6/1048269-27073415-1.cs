    public async Task<IEnumerable<IProduct>> getSearchQuery(string query)
        {
            var service = new ProductService();
            var result = await service.SearchProductAsync(query);
            return result;
        }
