    [HttpPost]
    public ActionResult Verwerk(int dag, String maand, int jaar)
    {
        var model = new MyViewModel
        {
            Dag = dag,
            Maand = maand,
            Jaar = jaar,
        };
        return View(model);
    }
