    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
    
        static class FixProblem
        {
            public static IEnumerable<T> FindAllThatNeedCreating<T, Complex>(this IEnumerable<Complex> list_of_complex, IEnumerable<T> list_of_T, Func<Complex, T> extract)
            {
                HashSet<T> T_in_list_of_complex = new HashSet<T>();
                foreach (Complex c in list_of_complex)
                    T_in_list_of_complex.Add(extract(c));
                List<T> answer = new List<T>();
                foreach (T t in list_of_T)
                    if (!T_in_list_of_complex.Contains(t))
                        answer.Add(t);
                return answer;
            }
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                // Test the code
                List<Tuple<int, int>> complex = new List<Tuple<int, int>>();
                List<int> simple = new List<int>();
    
                // Fill in some random data
                Random rnd = new Random();
                for (int i = 1; i < 600000; i++)
                    complex.Add(new Tuple<int, int>(rnd.Next(), rnd.Next()));
    
                for (int i = 1; i < 100000; i++)
                    simple.Add(rnd.Next());
    
                // This is the magic line of code:
                Console.WriteLine(complex.FindAllThatNeedCreating(simple, x => x.Item1).Count());
    
                Console.ReadKey();
    
            }
        }
    }
