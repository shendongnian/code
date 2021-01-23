    public ActionResult Index()
    {
        TempData[ "files" ] = GetFiles();
    
        RedirectToAction( "Files" );
    }
    
    public ActionResult Files()
    {
        var fileInfos = TempData[ "files" ];
    
        // do stuff with fileInfos
    }
