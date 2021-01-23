    using System.Text;
    using System.Threading.Tasks;
    using System.Numeric
     
    namespace TrailingZeroFromFact
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter a no");
                int no = int.Parse(Console.ReadLine());
                BigInterger fact = 1;
                if (no > 0)
                {
                    for (int i = 1; i <= no; i++)
                    {
                        fact = fact * i;
                    }
                    Console.WriteLine("{0}!={1}", no, fact);
                    string str = fact.ToString();
                    string[] ss = str.Split('0');
                    int count = 0;
                    for (int i = ss.Length - 1; i >= 0; i--)
                    {
                        if (ss[i] == "")
                            count = count + 1;
                        else
                            break;
                    }
                    Console.WriteLine("No of trailing zeroes are = {0}", count);
                }
                else
                {
                    Console.WriteLine("Can't calculate factorial of negative no");
                }
                Console.ReadKey();
            }
        }
    } 
