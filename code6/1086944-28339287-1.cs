	public class DriverSearchService : IDriverSearchService
    {
        private readonly IBlobService _blobService;
        private readonly IDataContext _dataContext;
        public DriverSearchService(IDataContext dataContext, IBlobService blobService)
         {
             _blobService = blobService;
            _dataContext = dataContext;
         }
		 
        public void SaveDriveSearch(int searchId)
        {
            // Fetch values from temp store and clear temp store
            var item = context.Query<SearchTempStore>().Single(s => s.SearchId == searchId);
            // Temp object is latest so update the main store
            var mainSearch = context.Query<Search>().Single(s => s.Id == searchId);
            mainSearch.LastExecutedOn = DateTime.UtcNow;
            mainSearch.DataAsBlob = item.DataAsBlob;
            context.Update(mainSearch);
        }
	}
