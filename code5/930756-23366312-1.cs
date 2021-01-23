    public class MyViewModel{
    LocationUpdate LocationUpadte{get;set;}
    User User{get;set;}
    }
        
    public ActionResult DisplayMap()
    {
            var model = (from locationUpdate in db.LocationUpdates
                                select new MyViewModel
                                {
                                    locationUpdate,
                                    locationUpdate.User
                                }).ToList();
            return View(model);
    }
