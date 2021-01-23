        public class Iterator 
        {
            public bool MoveNext()
            {
                return true;
            }
            public void Reset()
            {
               
            }
            public object Current { get; private set; }
        }
        public class Tester
        {
            public Iterator GetEnumerator()
            {
                return new Iterator();
            }
            public static void Loop() 
            {
               Tester tester = new Tester();
               foreach (var v in tester)
               {
                  Console.WriteLine(v);
               }
            }
        }
