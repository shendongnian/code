    public class PrincipalController : Controller
    {
      public ActionResult Index()
      {
        return View();
      }
      [HttpPost]
      public ActionResult Index(Cadastro cadastro)
      {
        try
        {
            //something
            cadastro.save();
        }
        catch
        {
            ViewBag.ErrorId = 1;
        }
        return View(cadastro);
      }
    }
