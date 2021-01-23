    namespace WindsorTest
    {
        public interface IHandlesEvent {}
    
        public interface IDontWantToBeRegistered {}
    
        namespace Select
        {
            public class SelectClass : IHandlesEvent { }
            public class DontRegisterMe : IDontWantToBeRegistered { }
        }
    
        namespace DontSelect
        {
            public class DontSelectClass: IHandlesEvent {}
        }
    
        
        internal class Program
        {
            private static void Main(string[] args)
            {
                var container = new WindsorContainer();
                container.Register(Classes.FromThisAssembly()
                    .InNamespace("WindsorTest.Select")
                    .BasedOn<IHandlesEvent>()
                    .WithServiceAllInterfaces()
                    );
                foreach (var handler in container.ResolveAll<IHandlesEvent>())
                {
                    Console.WriteLine(handler.GetType().Name);
                }
    
                foreach (var handler in container.ResolveAll<IDontWantToBeRegistered>())
                {
                    Console.WriteLine(handler.GetType().Name);
                }
                Console.ReadLine();
            }
        }
    }
