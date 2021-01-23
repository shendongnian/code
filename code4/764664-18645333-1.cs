    public class Program
    {
        private static void Main(string[] args)
        {
            var ws = new Regex("\\S");
            for (char c = '\0'; c != 0xffff; c++)
            {
                if (new String(c, 1).Trim().Length == 0)
                {
                    var m = ws.Match("" + c);
                    if (m.Value.Length != 0)
                    {
                        Console.Error.WriteLine("Found a mismatch: {0}", (int)c);
                    }
                }
            }
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
    //Output running in .NET 3.5:
    //Found a mismatch: 8203
    //Found a mismatch: 65279
    //done
    //Output running in .NET 4.0:
    //done
