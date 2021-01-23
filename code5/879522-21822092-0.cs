    static class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo();
            foo.Number = 7;
        }
    }
    public class Foo
    {
        private int number;
        public int Number
        {
            get
            {
                Console.WriteLine("In getter");
                return this.number;
            }
            set
            {
                Console.WriteLine("In setter");
                this.number = value;
            }
        }
    }
