    namespace Vurtual_Function
    {
        class First 
        {
            public virtual void Show() // --> Missing return type (void assumed)
            {
                Console.WriteLine("Class First");
            }
        }
        class Second : First 
        {
            public override void Show()  // --> Missing return type (void assumed)
            {
                Console.WriteLine("Class Second");
            }
            public static void Main()
            {
               Second obj = new Second();
               obj.Show();
               Console.ReadKey();
            }
         }
    }
