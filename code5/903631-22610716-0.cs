    public IEnumerable<IBulkResponse> ExportAllProducts(string indexName, int? productsCount)
        {
            var allTasks = ExportBulkProducts(indexName,productsCount);
            var results = new List<IBulkResponse>();
            try
            {
                var tokenSource2 = new CancellationTokenSource();
                var cancellationToken = tokenSource2.Token;
                Task.WaitAll(allTasks.ToArray<Task>(), cancellationToken);
                results = allTasks.Select(response => response.Result).ToList();
            }
            catch (AggregateException e)
            {
                var messages = new List<String>();
                messages.AddRange(e.InnerExceptions.Select(v => e.Message + " " + v.Message));
                throw new CustomException(messages);
            }
            return results;
        }
        /// <summary>
        /// Genete the tasks needed to run
        /// </summary>
        /// <param name="indexName">The index name</param>
        /// <param name="productsCount">The number of products to index</param>
        /// <returns>List of Tasks</returns>
        private IList<Task<IBulkResponse>> ExportBulkProducts(string indexName, int? productsCount)
        {
            var allTasks = new List<Task<IBulkResponse>>();
            using (var productRepository = new ProductRepository(new SearchContext()))
            {
                var totalProducts = productsCount ?? productRepository.TotalProducts();
                var itemsPerPage = 50;
                if (productsCount != null)
                {
                    var count = productsCount.Value;
                    itemsPerPage = count < 50 ? productsCount.Value : 50;
                }
                int totalPages = totalProducts / itemsPerPage;
                for (var i = 0; i < totalPages; i++)
                {
                    var products = productRepository.SelectAllProducts(itemsPerPage, itemsPerPage * i);
                    var response = Client.IndexAsync(indexName, typeof(ElasticSearchProduct), products, true);
                    allTasks.Add(response);
                }
            }
            return allTasks;
        }
