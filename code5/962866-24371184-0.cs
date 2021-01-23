    static class Program {
        static void Main() {
            Foo x = new Foo();
            if(x==null) {
                System.Console.WriteLine("Eek");
            }
        }
    }
    
    public class Foo {
        public static bool operator ==(Foo x,Foo y) {
            return true; // or something more subtle...
        }
    
        public static bool operator !=(Foo x, Foo y) {
            return !(x==y);
        }
    }
