    [RedirectOnException(ToAction = "B")]
    public ActionResult MarkeSettings()
    {
        SaveData();
        NotifyUser("success");
        return RedirectToAction("A");
    }
