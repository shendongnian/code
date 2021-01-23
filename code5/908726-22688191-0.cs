    static void AssertAreEqual<T1, T2>(T1 instance1, T2 instance2) {
      var properties1 = typeof(T1).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
      var properties2 = typeof(T2).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
      var properties = from p1 in properties1 
                       join p2 in properties2  on
                         p1.Name equals p2.Name
                       select p1.Name;
      foreach (var propertyName in properties) {
        var value1 = properties1.Where(p => p.Name == propertyName).First().GetGetMethod().Invoke(instance1, null);
        var value2 = properties2.Where(p => p.Name == propertyName).First().GetGetMethod().Invoke(instance2, null);
        Assert.AreEqual(value1, value2);
      }
    }
    public class PersonDto {
      public string LastName { get; set; }
      public int FieldFoo { get; set; }
      public int Dto { get; set; }
    }
    public class PersonModel {
      public string LastName { get; set; }
      public int FieldFoo { get; set; }
      public int Model { get; set; }
    }
    var p1 = new PersonDto { LastName = "Joe" };
    var p2 = new PersonModel { LastName = "Joe" };
    AssertAreEqual(p1, p2);
