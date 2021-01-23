    public class IndexViewModel
    {
        public SelectList Districts { get; set; }
        public int DistrictId { get; set; }
    
        public SelectList Thanas { get; set; }
        public int ThanaId { get; set; }
    }
    
    public class HomeController : Controller
    {
        private readonly Repository _repository = new Repository();
    
        public ActionResult Index()
        {
            // Should be refactored to handle empty collections
            var districts = _repository.GetDistricts().ToList();
            var firstDistrict = districts.First();
            var thanas = _repository.GetThanas(firstDistrict.Id).ToList();
            var firstThana = thanas.First();
            
            var vm = new IndexViewModel
            {
                Districts = new SelectList(districts, "Id", "Text", firstDistrict),
                DistrictId = firstDistrict.Id,
                Thanas = new SelectList(thanas, "Id", "Text", firstThana),
                ThanaId = firstThana.Id
            };
            
            return View(vm);
        }
    
        public ActionResult GetThanas(int districtId)
        {
            return Json(_repository.GetThanas(districtId), JsonRequestBehavior.AllowGet);
        }
    }
