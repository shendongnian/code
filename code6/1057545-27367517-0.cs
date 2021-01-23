    XElement xeBody =
        new XElement("Clients",
           // for each client in the list of all tables
           from client in lstAllTables
           //...group by client id into client group
           group client by client.ClientId into clientGroup
            //... for each client int the group create a <Client> element 
            select new XElement("Client",
               new XAttribute("ClientId", clientGroup.First().ClientId),
               new XAttribute("ClientName", clientGroup.First().ClientName),
               // for each contract in the current client group create a <Contract> element
               from contract in clientGroup
               select new XElement("Contract",
                  new XAttribute("ContractNumber", contract.ContractNumber),
                  new XAttribute("ContractDate", contract.ContractDate)
               )
           )
       );
