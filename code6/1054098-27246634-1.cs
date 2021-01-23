    [HttpPost]
    public ActionResult EditPackage(int id, string newPkgName)
    {
        try {
            //do logic here
            return Json(new { Success = true, Message = "OK"});
        }
        catch (Exception exc) {
            return Json(new { Success = false, Message = "An error occurred, please try later! " + exc.Message });
        }
    }
