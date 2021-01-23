    public ActionResult Index()
    {
        // SettingsModel smodel = new SettingsModel();
        // tblSettings tableset = new tblSettings();
        var dat = _Settings.GetSettings().ToDictionary(s => s.Desc, s => s.Settings, StringComparer.Ordinal);
        return View(dat); //dat is your model.
    }
