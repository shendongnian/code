    var xml = XElement.Parse(contents);
    
    var d = xml.Descendants("Tactic").Select(element => element.Parent != null ? new
        {
            id = element.Parent.Parent.Element("ProductId"),
            Tactic = new
                {
                    Typ = element.Descendants("Typ").FirstOrDefault().Value,
                    TPRFrom = element.Descendants("TPRFrom").FirstOrDefault().Value,
                    TprThru = element.Descendants("TprThru").FirstOrDefault().Value,
                    VF = element.Descendants("VF").FirstOrDefault().Value,
                    VT = element.Descendants("VT").FirstOrDefault().Value
                }
        } : null);
