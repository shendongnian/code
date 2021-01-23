    public class Person()
    {
      public long Id { get; set; }
      public string Name { get; set;}
      private Lazy<List<long>> _responsibleFor;
      public List<long> ResponsibleFor
      {
        get { return _responsibleFor.Value; }
      }
    
      public void SetResponsibleFor(Func<long, List<long>> getResponsibleFor)
      {
        _responsibleFor = new Lazy<List<long>>( () => getResponsibleFor(Id) );
      }
    
      public Person():base() { }
      public Person(long id, string name)
      {
        Id = id;
        Name = name
      }
     
    }
       // Implementation
       var p = new Person(1,"John Doe");
       p.SetResponsibleFor(GetResponsibleForPerson); //Pass a function/method which takes the long for input parameter and outputs List<long>
