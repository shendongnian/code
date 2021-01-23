    public class SportsController : Controller{
      // Your usual code
      public ActionResult InClub(int clubId){
        var sports = from s in db.Sport
                     join sic in db.SportInClub on s.SportId = sic.SportId
                     where sic.ClubId == ClubId 
                     select s
        return Json(sports);
      }
    }
