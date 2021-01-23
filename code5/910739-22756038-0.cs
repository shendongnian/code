     class Program
        {
            static void Main(string[] args)
            {
                var derived1=new Derived1();
                derived1.CommonWork();
    
                var derived2 = new Derived2();
                derived2.CommonWork();
    
                Console.Read();
            }
        }
    
        public abstract class BaseClass
        {
            public string ClassName;
    
            public T CommonWork<T>(T obj)
            {
                var baseClass = obj as BaseClass;
                Console.WriteLine( baseClass.ClassName);
                return obj;
            }
    
           
        }
    
        public class Derived1 : BaseClass
        {
            public Derived1 CommonWork()
            {
                this.ClassName = "Derived1";
              return  this.CommonWork(this);            
            }
    
        }
    
        public class Derived2 : BaseClass
        {
            public Derived2 CommonWork()
            {
                this.ClassName = "Derived2";
               return this.CommonWork(this);
               
            }
    
        }
