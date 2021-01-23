    class Program
    {
        public interface IName
        {
            string Name { get; }
        }
        public class myClass : IName
        {
            public string Name { get; set; }
            public myClass(string myName)
            {
                Name = myName;
            }
            public void changeIt()
            {
                Name = "xyz";
            }
        }
        public class myClass2 : IName
        {
            private IName iname;
            public string Name { get { return iname.Name; } }
            public myClass2(IName myName)
            {
                iname = myName;
            }
        }
        static void Main(string[] args)
        {
            myClass mClass = new myClass("abc");
            myClass2 m2Class = new myClass2(mClass);
            Console.WriteLine("myString:" + m2Class.Name);
            mClass.changeIt();
            Console.WriteLine("myString (After doThis):" + m2Class.Name);
            Console.ReadLine();
        }
    }
