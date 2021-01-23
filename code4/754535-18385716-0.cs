    var foundNode3 = root.Descendants(df + "Inv")
        .Where(e => e.Descendants(df + "Document")
                     .Any(item =>(string)item.Element(df + "InvS").Value == "N"))
        .Select(e =>
        {
            double value;
            string sValue = e.Element(df + "DocT").Element(df + "EndT").Value;
            if(double.TryParse(sValue, out value))
                return value;
            return 0;
        })
        .Sum();
