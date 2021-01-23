    using System;
    using System.Xml.Linq;
    
    string inputXml = "<Stuff><SomeStuff></SomeStuff></Stuff>";
    XDocument firstLossRootNode = XDocument.Parse("<Root />");
    XDocument economyDocument = XDocument.Parse(inputXml);
    
    firstLossRootNode.Root.Add(economyDocument.FirstNode);
