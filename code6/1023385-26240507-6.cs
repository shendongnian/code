    public ActionResult page(FormCollection collection)
    {
        App2Context db = new App2Context();
        Model dat = new Model();
        dat.Pupil.First = collection["firstName"];
        dat.Pupil.Last  = collection["lastName"];
        dat.Study.Subject = collection["Subject"];
        db.Models.Add(dat);
        db.SaveChanges();
        return View("Page2");
    }
