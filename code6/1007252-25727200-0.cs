    public interface IFooable
    {
         void Foo();
         void FooAgain();
    }
    public class Blah: IFooable
    {
         void IFooable.Foo()
         {
             Console.WriteLine("Hi from 'Blah'!");
         }
         void IFooable.FooAgain() {}
    }
    public class Bar: Blah, IFooable
    {
         void IFooable.Foo()
         {
             Console.WriteLine("Hi from 'Bar'!");
         }
    }
    public static void Main()
    {
       var fooList = new List<IFooable>();
       fooList.Add(new Blah());
       fooList.Add(new Bar());
       foreach (var fooable in fooList) //Outputs "Hi from 'Blah'!" / "Hi from 'Bar'!"
           fooable.Foo();
       Console.ReadLine();
    }
