    public class Test
    {
        public static explicit operator int(Test t) { return 42; }
        public override string ToString() { return "Test here!"; }
    }
    var test = new Test();
    Console.WriteLine(test); // "Test here!"
    Console.WriteLine((Test)test); // "Test here!"
    Console.WriteLine((int)test); // 42
    Console.WriteLine(test.ToString()); // "Test here!"
