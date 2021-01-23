    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // instanceMethod();  // Error calling instance method without an instance.
                                      // Won't even compile
                Program prg = new Program();
                prg.instanceMethod(); // No Error calling instance method from instance
                staticMethod(); // No Error calling static method without an instance
            }
        void instanceMethod()
        {
        }
        static void staticMethod() 
        {
        }
    }
}
