    public interface IMyInterface {
      DateTime CurrentDate {get; set}
      String SpecialProperty {get; set}
    }
    
    public class MyClassA: IMyInterface {...}
    
    public class MyClassB: IMyInterface {...}
    
    public class MyClassC: IMyInterface {...}
    
    ...
    
    private void OnCreate<T>(T value)
      where T: IMyInterface // <- T should implement IMyInterface
    {
      value.CurrentDate = DateTime.Now;
      value.SpecialProperty = "Hello";
    }
