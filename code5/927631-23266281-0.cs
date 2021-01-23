    class Program 
    {
       int number;
       
       static void Main(string[] args)
       {
            Program ObjProgram = new Program();
            ObjProgram.number = 10;                // works fine
            Console.ReadLine();
       }
    }
    class SomeOtherClass
    {
       void SomeMethod()
       {
            Program program = new Program();
            program.number = 10;                  // does not compile!
       }
    }
