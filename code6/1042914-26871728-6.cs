    public class MockServices : IServices
    {
        #region Constants
        const int DEFAULT_TIMELINE = 30;
        #endregion
        #region Singleton
        static MockServices _mockServices = null;
        private MockServices()
        {
        }
        public static MockServices Instance
        {
            get
            {
                if (_mockServices == null)
                {
                    _mockServices = new MockServices();
                }
                return _mockServices;
            }
        }
        #endregion
        #region Members
        IEnumerable<Warehouse> _supply = null;
        IEnumerable<Demand> _demand = null;
        IEnumerable<StockAlternative> _stockAlternatives = null;
        IConfirmationInteraction _refreshConfirmationDialog = null;
        IConfirmationInteraction _extendedTimelineConfirmationDialog = null;
        #endregion
        #region Boot
        public MockServices(IEnumerable<Warehouse> supply, IEnumerable<Demand> demand, IEnumerable<StockAlternative> stockAlternatives, IConfirmationInteraction refreshConfirmationDialog, IConfirmationInteraction extendedTimelineConfirmationDialog)
        {
            _supply = supply;
            _demand = demand;
            _stockAlternatives = stockAlternatives;
            _refreshConfirmationDialog = refreshConfirmationDialog;
            _extendedTimelineConfirmationDialog = extendedTimelineConfirmationDialog;
        }
        public IEnumerable<StockAlternative> LoadAlternativeStockCodes()
        {
            return _stockAlternatives;
        }
        public IEnumerable<Warehouse> LoadSupply(Lookup lookup)
        {
            return _supply;
        }
        public IEnumerable<Demand> LoadDemand(IEnumerable<string> stockCodes, int daysFilter, Syspro.Business.Lookup lookup)
        {
            return _demand;
        }
        public IEnumerable<Inventory> LoadParts(int daysFilter)
        {
            var job1 = new Job() { Id = Globals.jobId1, AssembledRequiredDate = DateTime.Now, StockCode = Globals.stockCode100 };
            var job2 = new Job() { Id = Globals.jobId2, AssembledRequiredDate = DateTime.Now, StockCode = Globals.stockCode200 };
            var job3 = new Job() { Id = Globals.jobId3, AssembledRequiredDate = DateTime.Now, StockCode = Globals.stockCode300 };
            return new HashSet<Inventory>()
            {
                new Inventory() { StockCode = Globals.stockCode100, UnitQTYRequired = 1, Category = "Category_1", Details = new PartDetails() { Warehouse = Globals.Instance.warehouse1, Job = job1} },
                new Inventory() { StockCode = Globals.stockCode200, UnitQTYRequired = 2, Category = "Category_1", Details = new PartDetails() { Warehouse = Globals.Instance.warehouse1, Job = job2} },
                new Inventory() { StockCode = Globals.stockCode300, UnitQTYRequired = 3, Category = "Category_1", Details = new PartDetails() { Warehouse = Globals.Instance.warehouse1, Job = job3} },
            };
        }
        #endregion
        #region Selection
        public Narration LoadNarration(string stockCode)
        {
            return new Narration()
            {
                Text = "Some description"
            };
        }
        public IEnumerable<PurchaseHistory> LoadPurchaseHistory(string stockCode)
        {
            return new List<PurchaseHistory>();
        }
        public AdditionalInfo GetSupplier(string stockCode)
        {
            return new AdditionalInfo()
            {
                SupplierName = "Some supplier name"
            };
        }
        #endregion
        #region Creation
        public Inject Dependencies(IEnumerable<Warehouse> supply, IEnumerable<Demand> demand, IEnumerable<StockAlternative> stockAlternatives, IConfirmationInteraction refreshConfirmation = null, IConfirmationInteraction extendedTimelineConfirmation = null)
        {
            return new Inject()
            {
                Services = new MockServices(supply, demand, stockAlternatives, refreshConfirmation, extendedTimelineConfirmation),
                Lookup = new Lookup()
                {
                    PartKeyToCachedParts = new Dictionary<string, Inventory>(),
                    PartkeyToStockcode = new Dictionary<string, string>(),
                    DaysRemainingToCompletedJobs = new Dictionary<int, HashSet<Job>>(),
    .
    .
    .
                },
                DaysFilterDefault = DEFAULT_TIMELINE,
                FilterOnShortage = true,
                PartCache = null
            };
        }
        public List<StockAlternative> Alternatives()
        {
            var stockAlternatives = new List<StockAlternative>() { new StockAlternative() { StockCode = Globals.stockCode100, AlternativeStockcode = Globals.stockCode100Alt1 } };
            return stockAlternatives;
        }
        public List<Demand> Demand()
        {
            var demand = new List<Demand>()
            {
                new Demand(){ Job = new Job{ Id = Globals.jobId1, StockCode = Globals.stockCode100, AssembledRequiredDate = DateTime.Now}, StockCode = Globals.stockCode100, RequiredQTY = 1}, 
                new Demand(){ Job = new Job{ Id = Globals.jobId2, StockCode = Globals.stockCode200, AssembledRequiredDate = DateTime.Now}, StockCode = Globals.stockCode200, RequiredQTY = 2}, 
            };
            return demand;
        }
        public List<Warehouse> Supply()
        {
            var supply = new List<Warehouse>() 
            { 
                Globals.Instance.warehouse1, 
                Globals.Instance.warehouse2, 
                Globals.Instance.warehouse3,
            };
            return supply;
        }
        #endregion
    }
