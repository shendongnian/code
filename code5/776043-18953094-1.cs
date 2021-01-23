    [HttpPost]
    public ActionResult SubmitSound(HttpPostedFileBase that_random_filename)
    {
        var fileName = Server.MapPath(string.Format("/Content/Sound/{0}.wav", Environment.TickCount));
        that_random_filename.SaveAs(fileName);
        return new JsonResult { Data = "Saved successfully" };
    }
