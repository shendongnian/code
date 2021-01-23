    class Program
    {  
        public interface IBadFoo
        {
            void DoSomethingUnusual();
        }
        public interface IFoo
        { 
            void DoSomething();
        }
        public class Foo : IFoo
        {
            public void DoSomething()
            {     	    
            }
        }
        public abstract class SomeGenericBase<IFooClass>
            where IFooClass : IFoo
            //where IFooClass : IBadFoo
        {
            public abstract void DoSomethingElse();
        }
 
        public class SomeGeneric<FooClass> : SomeGenericBase<FooClass>
            where FooClass : Foo, new()
        {
            public override void DoSomethingElse()
           {
               FooClass fc = new FooClass();
               fc.DoSomething();
           }
       }
       public static void Main()
       {
           SomeGeneric<Foo> someGen = new SomeGeneric<Foo>();
           someGen.DoSomethingElse();
       }
    }
