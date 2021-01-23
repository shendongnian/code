    class Program
    {
        public class CoroutineThing
        {
            public IEnumerator foo()
            {
                //Do something up here
                var nTimesInvoked = 0;
                while (bar(nTimesInvoked++))
                    yield return null; //Wait for bar to yield break
                //Do more stuff down here
                yield break;
            }
            bool bar(int nTimesInvoked)
            {
                if (nTimesInvoked < 5)
                {
                    Console.WriteLine("Bar: {0}", nTimesInvoked);
                    // Do something;
                }
                return nTimesInvoked < 4;
            }
        }
        public static void Main(params string[] args)
        {
            var cor = new CoroutineThing();
            var nFoo = 0;
            var e = cor.foo();
            while (e.MoveNext())
            {
                nFoo++;
                Console.WriteLine("{0} times foo", nFoo);
            }
            Console.ReadLine();
        }
    }
