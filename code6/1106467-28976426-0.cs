        public interface IhappyObject
        {
            void Print();
        }
        public class HappyObject : IhappyObject
        {
            private IhappyObject obj;
            public HappyObject(IhappyObject obj)
            {
                this.obj = obj;
            }
            public void Print()
            {
                obj.Print();
            }
        }
        public class VeryHappyObject : IhappyObject
        {
            public void Print()
            {
                Console.WriteLine("I'm very happy");
            }
        }
        public class SuperHappyObject : IhappyObject
        {
            public void Print()
            {
                Console.WriteLine("I'm super happy!");
            }
        }
        static void Main(string[] args)
        {
            HappyObject obj = new HappyObject(new SuperHappyObject());
            obj.Print();
        }
