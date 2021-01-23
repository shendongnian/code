    public class Person
    {
        public string Name {get;set;}
        public Person(int Id)
        {
            var oDataService = new ODataService(new Uri("YourURL"));
            Name = oDataService.Persons.Where(x=>x.Id == Id).Select(x=>x.Name);
        }
    }
