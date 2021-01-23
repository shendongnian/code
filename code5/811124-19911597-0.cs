    public abstract class MyDataObject{
      public string SomeSharedProperty{get;set;}
      protected abstract DoSomething(); 
    }
    
    public class FirstType: MyDataObject{ 
      protected override DoSomething(){
        Console.WriteLine(SomeSharedProperty);
      }
    }
    
    
    public class Consumer{
      public void DoSomethingWithAllMyTypes(List<MyDataObject> source)
      {
        source.ForEach(x=>x.DoSomething());
      }
    }
