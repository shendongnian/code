    public interface IAgeable {
     MyAge {get;set}
    }
    public class MyAge:IAgeable{
       public MyAge(int age){
           MyAge = age;
      }
       int MyAge { get; internal set; }
    }
