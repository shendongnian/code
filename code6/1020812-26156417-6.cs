    [HttpPost]
    public ActionResult GetWeekStamp(GetWeekStampModel model)
    {
        return RedirectToAction("Stampings", new { year = model.Year, weekNo = model.WeekNo });
    }
