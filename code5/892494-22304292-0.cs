    public class Test
    {
        private static int capture = 0;    
        static IEnumerable<Action> Get()
        {
            for (int i = 0; i < 2; i++)
            {
                capture++;
                yield return () => Console.WriteLine(capture.ToString());
            }
        }
    }
