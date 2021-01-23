    public partial class Person {
      public Person() { 
        _dotnetType = this.GetType().Fullname; 
        _dotnetAssembly = this.GetType().Assembly.Fullname; 
      }
      private string _dotnetType;
      private string _dotnetAssembly;
      public string DotNetType { get { return _dotnetType; } set { _dotnetType = value } }
      public string DotNetAssembly { get { return _dotnetAssembl; } set { _dotnetAssembly = value } }
    }
    // Example usage
    var peeps = from person in Entities.Persons
                select new { Name = person.Name, Type = DotNetType, Assembly = DotNetAssembly };
    var loadedPeople = peeps.ToList() // enumerate it
                       .Select( p => {
                         var instance = Activator.CreateInstance(p.Assembly, p.Type);
                         var property = p.GetType().GetProperties().First(prop => prop.Name == "Name");
                         property.SetValue(instance, p.Name, null);
                       });
