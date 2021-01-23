    public class City
    {
      public string Name { get; set; }
      [StateId(10)]
      public virtual State State { get; set; }
    }
    
    var sCity = Substitute.For<City>();
    sCity.State.Returns((core) => {return null; // here you can access informations about the call});
