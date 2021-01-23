    public sealed class IndexViewModel : LayoutViewModel
    {
        public IndexViewModel(IEnumerable<StaffMemberModel> staff)
        {
            StaffMembers = staff;
        }
        
        public IEnumerable<StaffMemberModel> StaffMembers { get; private set; }
    }
    public ActionResult Index()
    {
        var models = new JsonFileReader()
            .GetModelFromFile<List<Staff>>(@"~/App_Data/Staff.json")
            .Select(inputModel =>
                new StaffMemberModel()
                {
                    FullName="yourvalidationHere",
                    CorparateTitle="yourvalidationhere"
                });
        return new View(new IndexViewModel(models));
    }
