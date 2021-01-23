    public JsonResult Upload(VoicePassage passage)
    {
        // Validate the input
        // ...
        // ...
     
        // Save the file
        string path = Server.MapPath(string.Format("~/Recordings/{0}.wav", passage.FileName));
        passage.Recording.SaveAs(path);
     
        return Json(new { Success: true });
    }
