    public class AnimalController : Controller
        {
            //
            // GET: /Animal/
    
            public ActionResult Index()
            {
                AnimalModels model = new AnimalModels();
                model = new AnimalModels(); 
                //[B]the update
                model.AnimalList = new List<SelectListItem>(); 
                model.AnimalList.Add(new SelectListItem { Value = "0", Text = "Tiger" }); 
                model.AnimalList.Add(new SelectListItem { Value = "1", Text = "Lion" });
                //[E]the update
                return View(model);
            }
    
            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Index(AnimalModels model)
            {
                //[B]the update
                model.AnimalList[int.Parse(model.AnimalId)].Selected = true;
                //[E]the update
                return View(model);
            }
    
    }
