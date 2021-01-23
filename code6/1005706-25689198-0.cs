    private async static Task<List<Person>> GetPeopleList(string colSelfLink)
    {
       dynamic doc = client.CreateDocumentQuery<Document>(colSelfLink, "SELECT p.PersonId, p.FirstName, p.MiddleName, p.LastName, p.Gender FROM People p").AsEnumerable().ToList();
       List<Person> peopleList = new List<Person>();
       if (doc != null)
       {
          Person person;
          foreach(var item in doc)
          {
             person = JsonConvert.DeserializeObject<Person>(item.ToString());
             peopleList.Add(person);
          }
       }
       return peopleList;
    }
