    public class TranslationController : Controller
    {
       public ActionResult Search_Query()
       {
           List<Surah> Records = someService.GetSurah();
           ...
           return Json(new { key = Records }, JsonRequestBehavior.AllowGet);
       }
    }
    public class Surah_CRUDController : Controller
    {
       public ActionResult Load_Surahs() 
        {
             List<Surah> Records = someService.GetSurah();
             ...
             return Json(new { key = Records }, JsonRequestBehavior.AllowGet);
        }
    }
