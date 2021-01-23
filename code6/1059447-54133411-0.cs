        /// <summary>
        /// An endpoint that processes a batch of records.
        /// </summary>
        /// <param name="provider">The service provider to use to create scoped DB contexts.
        /// This is injected by DI due to the FromServices attribute.</param>
        /// <param name="records">The batch of records.</param>
        public async Task<IActionResult> PostRecords(
            [FromServices] IServiceProvider provider,
            Record[] records)
        {
            // The service scope factory is used to create a scope per iteration
            var serviceScopeFactory = provider.GetRequiredService<IServiceScopeFactory>();
            foreach (var record in records)
            {
                // At the end of the using block, scope.Dispose() will release the DbContext
                // so it will stop tracking objects from the past iteration
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<MainDbContext>();
                    // Query and modify database records as needed
                    await context.SaveChangesAsync();
                }
            }
            return Ok();
        }
