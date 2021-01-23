    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var plane = new Scanner();
        var model = await plane.GetSuggestions("ISTANBUL");
    
        return View(model);
    }
