    XDocument assets = XDocument.Load("assets.xml");
    var lookup = assets.Root.Elements("Asset")
                            .ToLookup(x => (int) x.Element("ContractNo"));
    assets.Root.Elements("Asset").Elements("ContractNo").Remove();
    XDocument contracts = XDocument.Load("contracts.xml");
    foreach (var contract in contract.Root.Elements("Contract").ToList())
    {
        var id = (int) contract.Element("ContractNo");
        contact.Add(lookup[id]);
    }
    contracts.Save("results.xml");
