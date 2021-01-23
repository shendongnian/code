    namespace WindowsFormsApplication1
    {
    class foo
    {
    
        static void Main(string[] args)  // Initial Solution
        {
               Application.EnableVisualStyles();
               " 
                   "
        }
    
         public void callSomeMethod( r )
         {
              //call someMethod from foo class - this step is my problem
         }
    }
    
    
    class bar  
    {
    
          public static bar()
          {
               //init
          }
           public void someMethod(r1 r2)
           {
               Console.WriteLine("r1: {0}",  r2.get());
               Console.ReadKey();   // Similar To Getch(); in C [ Hold The Answer ]
           }
    }
