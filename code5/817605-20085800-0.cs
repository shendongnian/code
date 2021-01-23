    public class Program
    {
        public static unsafe void Main(string[] args)
        {
            int foo = 10;
            int* fooPointer = &foo; //get the pointer to foo
            Console.WriteLine(foo); //here we can see foo is 10
            *fooPointer = 11; //update foo through the pointer
            Console.WriteLine(foo); //now foo is 11
        }
    }
