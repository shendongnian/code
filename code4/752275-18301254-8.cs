    var client = new Client();
    var debtor = new Debtor();
    var agreement = new Agreement();
    
    agreement.Client = client;
    client.Agreements.Add(agreement);
    
    agreement.Debtors.Add(debtor);
    debtor.Agreements.Add(agreement);
    
    session.Save(client);
    session.Flush();
