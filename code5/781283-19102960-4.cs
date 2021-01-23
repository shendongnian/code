    public interface IDoSomething
    {
        void DoSomething();
    }
    
    public class Dog : Animal, IDoSomething
    {
         public void Bark()
         {
         }
         void IDoSomething.DoSomething(){
             Bark();
         }
    }
    
    public class Cat : Animal, IDoSomething
    {
         public void Meow()
         {
         }
         void IDoSomething.DoSomething(){
             Meow();
         }
    }
