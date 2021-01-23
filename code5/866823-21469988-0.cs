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
