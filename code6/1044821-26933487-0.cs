    public interface IAgable {
     MyAge {get;set}
    }
    public class MyAge{
       public MyAge(int age){
           Age = age;
      }
       int Age { get; internal set; }
    }
