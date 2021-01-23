    public ViewResult Index()
    {
        _clientModel = InitialiseBarClientsModel();
        return View(_clientModel);
    }
    [HttpPost]
    public PartialViewResult PopulateEmailAddressUI(string clientID)
    {
        _clientModel = InitialiseBarClientsModel();
        _clientModel.FindEmailAddresses(from client in eFormsDB.BAR_Clients where client.ClientId == clientID select client);
        return PartialView("~/Views/Home/EmailAddressGrid.cshtml", _clientModel);
    }
    public PartialViewResult EmailAddressGrid()
    {
        _clientModel = InitialiseBarClientsModel();
        return PartialView("~/Views/Home/EmailAddressGrid.cshtml", _clientModel);
    }
    [HttpPost]
    public PartialViewResult AddEmailAddress(EmailInfo emailInfo)
    {
        _clientModel = InitialiseBarClientsModel();
        string updatedEmail = _clientModel.AddEmail(from client in eFormsDB.BAR_Clients where client.ClientId == emailInfo.clientID select client, emailInfo.emailAddress);
        var clientToUpdate = eFormsDB.BAR_Clients.Find(emailInfo.clientID);
        try
        {
            eFormsDB.Entry(clientToUpdate).Member("EmailAddress").CurrentValue = updatedEmail;
            eFormsDB.Entry(clientToUpdate).Member("InvoiceMode").CurrentValue = emailInfo.invoiceMode;
            eFormsDB.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("General Exception occurred while saving to database");
        }
        _clientModel.FindEmailAddresses(from client in eFormsDB.BAR_Clients where client.ClientId == emailInfo.clientID select client);
        return PartialView("~/Views/Home/EmailAddressGrid.cshtml", _clientModel);
    }
    private BarClientsViewModel InitialiseBarClientsModel()
    {
        BarClientsViewModel clientModel = new BarClientsViewModel(from meditech in meditechDB.veForms_BAR_Clients select meditech);
        return clientModel;
    }
