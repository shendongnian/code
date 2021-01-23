    public ActionResult Upload()
    {
        var file = Request.Files["Filedata"];
        string savePath = Server.MapPath(@"~\mp3\" + file.FileName);
        file.SaveAs(savePath);
        return Content(@"~\mp3\" + file.FileName);
    }
