    [HttpPost]
    public ActionResult UpdatePoints()
            {
    
                ViewBag.points =  _Repository.Points;
                return PartialView("UpdatePoints");
            }
