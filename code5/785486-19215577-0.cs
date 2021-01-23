        public class MyClass {
            public List<int> Params = new List<int>();
            public void Load(int data) {
                Params.Add(data);
                }
            }
    class Program {
        static void Main(string[] args) {
            var one = new MyClass();
            var two = new MyClass();
            var three = new MyClass();
 
            one.Load(25);
            two.Load(50);            
            three.Load(75);
            Console.WriteLine(one.Params.Count());
            }
         }
