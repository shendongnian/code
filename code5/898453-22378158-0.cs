    public class City
    {
      public string Name { get; put; }
      [StateId(10)]
      public virtual State State { get; put; }
    }
    
    var sCity = Substitute.For<City>();
    sCity.State.Returns((core) => {return null; // here you can access informations about the call});
