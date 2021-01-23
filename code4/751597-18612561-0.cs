    var xmlcontacts = xmlloaded.Descendants("schema_name").Where(node => (string)node.Attribute("value") == comboSchema.SelectedValue.ToString());
        foreach (XElement subelement in xmlcontacts.Descendants("contact")) //element is variable
        {
            contact.Add(new Contact()
            {
                id = subelement.Element("id").Value,
                firstName = subelement.Element("firstName").Value,
                lastName = subelement.Element("lastName").Value,
                department = subelement.Element("department").Value,
                emailAddress = subelement.Element("emailAddress").Value,
                lineManagerId = subelement.Element("lineManagerId").Value,
                //_phonenumbers = phones
            });
            foreach (XElement phoneElement in subelement.Descendants("telephone_number"))
            {
                //add telephone_number details in list here
            }
        }
