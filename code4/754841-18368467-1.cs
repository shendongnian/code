    public ActionResult Debug2(string arg1)
    {
        var model = new List<Type1>();
        model.Add(new Type1 { IPAddress = "192.168.1.1", ConnectionId = "123" });
        model.Add(new Type1 { IPAddress = "192.168.1.2", ConnectionId = "345" });
        return View(model);
    }
