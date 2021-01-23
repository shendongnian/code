    namespace Outissue
    {
        class Program
        {
            static int Method(out  int i, out int j, out int k)
            {
                i = 100;
                j = 200;
                k = 300;
                int d = i + j + k;
                return d;
            }
            static void Main(string[] args)
            {
                int total, a ,b,c;
                total = Method(out a,out  b, out  c);
                Console.WriteLine(total);
            }
        }
    }
