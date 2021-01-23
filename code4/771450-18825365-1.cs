    public struct MyStruct
    {
        public void WriteSomething()
        {
            Console.WriteLine("Hello");
        }
    }
    MyStruct traceLevelOptions;
    Console.WriteLine(traceLevelOptions.ToString());
    traceLevelOptions.WriteSomething();
