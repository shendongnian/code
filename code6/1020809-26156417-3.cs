    public ActionResult Stampings(Stamping model)
    {            
        var startTime = DateConverter.FirstDateOfWeek(model.Timestamp);
        var endTime = startTime.AddDays(6);
        var userId = (int)Session["userId"];
        var stampings = _db.Stampings.Where(s => s.Timestamp >= startTime && s.Timestamp <= endTime)
            .Where(s => s.UserId == userId).ToList();
        var stampingModel = new StampingModel();
        stampingModel.Stampings = stampings;
        stampingModel.Timestamp = model.Timestamp;
        return View(stampingModel);
    }
