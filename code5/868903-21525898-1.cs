     public class ListController : Controller
        {
            public ActionResult Index()
            {
                ImageViewModel model;
                using (SampleEntities entities = new SampleEntities())
                {
                    model = (from p in entities.Images
                                         where p.ImageId == "1"
                                         select new ImageViewModel()
                                         {
                                             ImageId = p.ImageId,
                                             ImageUrl = p.ImageUrl,
                                             Comments = p.ImageComments.Select(pa => pa.Comment).ToList()
                                         }).FirstOrDefault();
                }
    
                return View(model);
            }
    	}
