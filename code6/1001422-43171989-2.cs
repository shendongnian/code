     class Program
     {
            static void TimerProcedure(object param)
            {
                Console.Clear();
                Console.WriteLine(DateTime.Now.TimeOfDay);
             
                GC.Collect();
        
            }
    
            static void Main(string[] args)
            {
                Console.Title = "Desktop Clock";
                Console.SetWindowSize(20, 2);
                Timer timer = new Timer(TimerProcedure, null,
                    TimeSpan.Zero, TimeSpan.FromSeconds(1));
                Console.ReadLine();
            }
        }
