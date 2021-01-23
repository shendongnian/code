    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new EmployeeMasterViewModel();
            vm.Employee = new EmployeeViewModel();
            vm.Skills = new List<SkillViewModel>();
    
            return View(vm);
        }
    
        [HttpPost]
        public ActionResult Index(EmployeeMasterViewModel viewModel)
        {
            return View(viewModel);
        }
    }
