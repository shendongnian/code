    namespace ConsoleApplication1
    {
        class ConsoleApplication1
        {
          
            static void Main()
            {
                CS_Test_Class testClass = new CS_Test_Class();
                testClass.hello();
                testClass.hello_test1();
                  
                Console.ReadKey();
                testClass.Dispose();
               
            }
    
        }
    }
