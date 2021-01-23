    [Route("/HaveChristmas", "GET")]
    [MyRole("Santa","Rudolph","MrsClaus")] // Notice our custom MyRole attribute.
    public class HaveChristmasRequest {}
    [Route("/EasterEgg", "GET")]
    [MyRole("Easterbunny")]
    public class GetEasterEggRequest {}
    [Route("/EinsteinsBirthday", "GET")]
    public class EinsteinsBirthdayRequest {}
