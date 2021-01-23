    [HttpPost]
    public ActionResult SubmitSound(SoundBlob blob)
    {
            var fileName = Server.MapPath(string.Format("/Content/Sound/{0}.wav", Environment.TickCount));
            blob.blob.SaveAs(fileName);
            return new JsonResult { Data = "Saved successfully" };
    }
