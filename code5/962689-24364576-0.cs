    DomainServiceSoapClient service = new DomainServiceSoapClient();
         foreach (string name in myListOfNames)
        {
            Person newPerson = new Person() {Name = name};
            service.Person.Add(newPerson);
    
        }
    service.SubmitChanges();
