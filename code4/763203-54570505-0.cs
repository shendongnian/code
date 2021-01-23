    if (app.Session.CurrentUser.AddressEntry.Type == "EX") {
        createdby = app.Session.CurrentUser.AddressEntry.GetExchangeUser().PrimarySmtpAddress;
    } else {
        createdby = app.Session.CurrentUser.AddressEntry.Address;
    }
