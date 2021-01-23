    Class T{
        private static void Foo(){
           // do sth.
        }
    
        public class InnerClass{
           public static void Bar(){
              Foo(); //no Problem.
           }
        }
    }
