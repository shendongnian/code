    public partial class MyDfsUtil : IDataPackageService, IFooService
    {
        public string Locale { get; set; }
        public string DfsServiceUrl { get; set; }
        public string UserName { get; set; }
    
        public DataPackage GetObjectsWithContent()
        {
            //Some code here
        }
    }
