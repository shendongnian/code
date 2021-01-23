    public ActionResult GetContentFromFTP()
    {
    	string[] FTP_Imagery = Directory.GetFiles(@"F:\abc\imgfiles\Imagery\");
        string[] FTP_Audio = Directory.GetFiles(@"F:\abc\audiofiles\Audio\");
    	
    	var viewModel = new ShowFilesViewModel() 
    	{
    		Images = FTP_Imagery;
    		Audio = FTP_Audio;
    	};
    	
    	return View("showfiles", viewModel);
    }
