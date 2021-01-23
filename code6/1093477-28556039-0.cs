        XDocument Doc = XDocument.Parse(strFileData);
        var Result = (from Root in Doc.Descendants(XName.Get("ROOT", "authenticateUser"))
                      select new
                      {
                          PARTYCODE = Root.Element(XName.Get("PARTYCODE", "authenticateUser")).Value ?? string.Empty,
                          VRETCODE = Root.Element(XName.Get("VRETCODE", "authenticateUser")).Value ?? string.Empty,
                          PRETCODE = Root.Element(XName.Get("PRETCODE", "authenticateUser")).Value ?? string.Empty,
                          VRETERR = Root.Element(XName.Get("VRETERR", "authenticateUser")).Value ?? string.Empty,
                      }).ToList();
