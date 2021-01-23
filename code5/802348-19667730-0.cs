    IList<Party> GetParties(string name, string organizationName)
    {       
       IList<Party> result = new List<Party>();
       using(var context = new MyContext())
       { 
          var persons = context.Parties.OfType<Person>().Where(t=>t.LastName = name) ;
          var organizations = context.Parties.OfType<Organization>().Where(t=>t.Name.StartWith(organizationName));
          //return merge of persons and organizations 
          result = (IList<Party>)persons.Union((IEnumerable<Party>)organizations);          
       }
       return result;
    }
