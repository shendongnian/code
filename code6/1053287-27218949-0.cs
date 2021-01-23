    using System.Text;
    using System.Threading.Tasks;
    namespace Week_9_Ex1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program fix = new Program();
                Console.WriteLine(fix.FixTypo("The Wilking Dead", 5, "a"));
            }
            public string FixTypo(string needCorrect, int index, string replacement)
            {
                return string.Concat(needCorrect.Substring(0, index), replacement, needCorrect.Substring(index+1));
            }
        }
    }
