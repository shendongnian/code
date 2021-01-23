    class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(new ClassA().IsEvenDayToday()); // Result: true 
                Console.WriteLine(new ClassB().IsEvenDayToday()); // Result: false
    
                Console.ReadKey();
            }
        }
    
        public class ClassA : ClassB
        {
            public new bool IsEvenDayToday()
            {
                return DateTime.Now.Day % 2 == 0;
            }
        }
    
        public class ClassB
        {
            public bool IsEvenDayToday()
            {
                return DateTime.Now.Day % 2 != 0;
            }
        }
