    public class Supplier
    {
    	public string SupplierName { get; set; }
    	public decimal SupplierLatitude { get; set; }
    	public decimal SupplierLongitude { get; set; }
    }
    [HttpGet]
	public ActionResult Index()
	{
		ViewBag.supliersContext = new List<Supplier>()
		{
			new Supplier() { SupplierName = "Test1", SupplierLatitude = 32.071953M, SupplierLongitude = 34.787868M },
			new Supplier() { SupplierName = "Test2", SupplierLatitude = 31.571953M, SupplierLongitude = 34.787868M },
			new Supplier() { SupplierName = "Test3", SupplierLatitude = 31.071953M, SupplierLongitude = 34.787868M },
		};
		return View();
	}
