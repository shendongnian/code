    _phoneNumbers = subelement.Element("telephone_number").Elements()
                    .Where(e => e.Name.StartsWith("number").Select(e => 
                    new PhoneInfo
                    {
                      Number = e.Value,
                      Retries = subelement.Element("telephone_Number").Element(
                      "retries" + e.SubString(5)).Value,
                      NumberType = subelement.Element("telephone_Number").Element(
                      "numbertype" + e.SubString(5)).Value
                    })
