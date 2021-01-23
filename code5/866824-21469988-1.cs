    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(ClientModel credential)
    {
        var client = new Client
        {
           Name = model.Name,
           EmailAddress = model.EmailAddress,
           .
           .
        };
        
        db.Clients.Add(client);
        db.SaveChanges();
        
        model.ID = client.ID;
        
        return View(model);
    }
