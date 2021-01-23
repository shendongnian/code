    public class Foo {
        public string Name { get; private set; }
        public Foo(string name) {
            Name = name;
        }
    }
    public class Program {
        public static void Example(ref Foo f) {
            // This will print "original"
            Console.WriteLine("Example() was given {0}", f.Name);
            // We assign a new instance to the reference which was
            // passed by reference
            f = new Foo("replacement");
        } 
        public static void Main() {
            Foo f;                       // This variable is a "reference" to a Foo
            f = new Foo("original");     // We assign a new instance to that variable
            Example(ref f);
            // This will print "replacement"
            Console.WriteLine("After calling Example(), f is {0}", f.Name);
        }
    }
