    public IEnumerable<Person> GetPeople()
    {
        foreach (XElement datatype in RepDoc.Element("People").Descendants("Persons"))
        {
            var p = new Person
            {
                Name = datatype.Element("Name").Value,
                SurName = datatype.Element("SurName").Value
            };
            yield return p;
        }
    }
