    public ActionResult Index()
    {   
        var teams = db
            .Teams
            .Include("Players") // Assuming your Team entity has a collection of Players
            .SelectMany(t => new TeamVM { 
                ID = t.ID, 
                // etc.. 
            })
            .ToList();   
        return View(new TeamViewModel { Teams = teams });
    }
