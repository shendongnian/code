    public class PagedCollectionFactory
    {
        public static IPagedCollection<TModel> GetAsPagedCollection<TModel, TCollection>(int currentPage, int totalPages, int totalCount, TCollection page)
            where TCollection : IModelCollection<TModel>
            where TModel : IPersistableModel
        {
            var generator = new ProxyGenerator();
            var options = new ProxyGenerationOptions();
            options.AddMixinInstance(new PagingDetails { CurrentPage = currentPage, TotalPages = totalPages, TotalCount = totalCount });
            return (IPagedCollection<TModel>)generator.CreateClassProxyWithTarget(typeof(TCollection), new[] { typeof(IPagedCollection<TModel>) }, page, options);
        }
    }
