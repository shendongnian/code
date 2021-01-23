    private static Subdepartment GetSubdepartmentForXmlElement(XElement subdept)
    {
        if (subdept == null) throw new ArgumentNullException("subdept");
        var idElement = subdept.Element("Id");
        var accountIdElement = subdept.Element("AccountId");
        var nameElement = subdept.Element("Name");
        if (idElement != null && accountIdElement != null && nameElement != null)
        {
            return new Subdepartment
            {
                Id = Convert.ToInt32(idElement.Value),
                AccountId = Convert.ToDouble(accountIdElement.Value),
                Name = nameElement.Value
            };
        }
        return null;
    }
