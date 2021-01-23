    public ActionResult GetContentFromFTP()
    {
        string[] FTP_Imagery = Directory.GetFiles(@"F:\abc\imgfiles\Imagery\");
        string[] FTP_Audio = Directory.GetFiles(@"F:\abc\audiofiles\Audio\");
        ViewBag.Add("FTP_Imagery", FTP_Imagery);
        ViewBag.Add("FTP_Audio", FTP_Audio);
        return View("showfiles");
    }
	
