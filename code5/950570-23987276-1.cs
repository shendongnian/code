        public class Element
        {
            public string CLASS_NAME = "___ELEMENT___";
    
        }
    
        public class Arc : Element
        {
            public new string CLASS_NAME = "___ARC___";
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Arc a = new Arc();
    
                Console.WriteLine(a.CLASS_NAME);
                Console.WriteLine((a as Element).CLASS_NAME);
    
                Console.ReadLine();
            }
        }
