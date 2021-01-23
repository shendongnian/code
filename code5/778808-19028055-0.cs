    XmlDocument doc = new XmlDocument();
    doc.Load(responseStream);
    XmlNodeList list = doc.DocumentElement.SelectNodes("//item");
    foreach (XmlNode n in list)
    {
        XmlNode OfferId     = n.SelectSingleNode("candidate_offer_id");
        XmlNode Contact     = n.SelectSingleNode("contact_person");
        XmlNode OfferStatus = n.SelectSingleNode("offer_status");
        Console.WriteLine(OfferId.InnerText);
        Console.WriteLine(Contact.InnerText);
        Console.WriteLine(OfferStatus.InnerText);
    }
I am presuming that the `` tags are in error; if not, the xml will need correcting before if can be used.
