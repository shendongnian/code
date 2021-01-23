    var test = HtmlBuilders.BuildCollapsibleHtmlTable<Client>(
               Model.Clients,
               //new KeyValuePair<string, string>[] { 
               new[] {  // Shorter
                   new KeyValuePair<string, string> ("Client", "tdCSSLeft"),
                   new KeyValuePair<string, string> ("Debt", "tdCSSCenter")
               },
               (client => client.ClientName),
               (client => client.TotalDebt),
               // tableDataColumnDefinitions
               (clients => clients.ClientName),
               (clients => clients.ClientSurname),
               (clients => clients.ClientAddress)
           );
