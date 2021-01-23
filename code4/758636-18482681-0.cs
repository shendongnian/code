     ...
        Trip NewTrip = new Trip();
        NewTrip.Date_Departed = DateTime.Now;
        return View(NewTrip); // <- your method will always return here, no code below will ever execute 
        // These code below is unreachable: it will never be executed.
        // So the compiler advise (via warning) you either to delete (or comment out) the code below
        // or change return View(NewTrip) line
        // the client names 
        List<Client> ClientList = new List<Client>(); 
        var ClientQuery1 = from b in db.Clients
                         orderby b.Client_Name
                         select b;
        ClientList.AddRange(ClientQuery1);
        ViewBag.ClientId = new SelectList(ClientList, "ClientId", "Client_Name");
        return View();
    }
