    [GridAction]
    public ActionResult Index()
    {
        IEnumerable<Client> clients = clientRepository.GetClients();
        return View(new GridModel(clients.Select(a => new { ClientId = a.ClientId, Name = a.Name, Address = a.Address })));
    }
