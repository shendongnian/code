    struct SomeStruct 
    {
        public int Value;
        public static void DoSomething(ref SomeStruct instance)
        {
            Console.WriteLine(instance.Value);
        }
    }
    
    SomeStruct c; // this is placed on stack
    SomeStruct.DoSomething(ref c); // this passes a pointer to the stack and jumps to the method call
    
