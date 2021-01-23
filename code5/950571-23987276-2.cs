        public class Element
        {
            public const string CLASS_NAME = "___ELEMENT___";
        }
        public class Arc : Element
        {
            public new const string CLASS_NAME = "___ARC___";
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Arc a = new Arc();
                Console.WriteLine(Arc.CLASS_NAME);
                Console.WriteLine(Element.CLASS_NAME);
                Console.ReadLine();
            }
        }
