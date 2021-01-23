    class B
    {
         public void Method1(Action<string> PrintOutput)
         {
            var C = new C();
            C.Method2(PrintOutput);
         }
    }
    class C
    {
         public void Method2(Action<string> PrintOutput)
         {
             PrintOutput("Bye!");
         }   
    }
