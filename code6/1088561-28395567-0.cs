    static class Program
    {
        static void Main()
        {
            var myStruct = new MyStruct();
            Console.WriteLine(myStruct.i); // prints 0
            Console.WriteLine(myStruct.ToString()); // modifies myStruct, not a copy of myStruct
            Console.WriteLine(myStruct.i); // prints 1
        }
        struct MyStruct {
            public int i;
            public override string ToString() {
                i = 1;
                return base.ToString();
            }
        }
    }
