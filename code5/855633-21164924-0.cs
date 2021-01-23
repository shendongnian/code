    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {
            var iScenarios = 6;
            var iStart = 0;
            var iEnd = 1000;
            var totalResults = new List<double>();
     
            Parallel.For(0, iScenarios, k => {
                List<double> calcResults = new List<double>();
                for (int n = iStart; n < iEnd; n++)
                    calcResults.AddRange(CalcRoutine(n, k));
                lock (totalResults)
                {
                    totalResults.AddRange(calcResults);
                }
            });           
        }
        static IEnumerable<double> CalcRoutine(int a, int b)
        {
            yield return 0;
        }
        static double[] SumOfResults(IEnumerable<double> source)
        {
            return source.ToArray();
        }
    }
