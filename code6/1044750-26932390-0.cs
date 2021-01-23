    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Test1
    {
        class Program
        {
            static void PrintOut<T>(IEnumerable<IEnumerable<T>> data)
            {
                foreach (var item in data)
                {
                    string output = "-";
                    if (item != null)
                        output = string.Join(",", item.Select(x => (x == null) ? "-" : x.ToString()));
                    Console.WriteLine(output);
                }
            }
    
    
            static IEnumerable<T> Yield<T>(T item)
            {
                yield return item;
            }
    
    
            static IEnumerable<T> ConcatItem<T>(IEnumerable<T> enumerable, T item)
            {
                return enumerable == null ? Yield(item) : enumerable.Concat(Yield(item));
            }
    
            static IEnumerable<IEnumerable<T>> helper2<T>(IEnumerable<IEnumerable<T>> input) where T : class
            {
                var initalAcc = Enumerable.Empty<IEnumerable<T>>();
                var result = input.Aggregate(initalAcc,
                    (acc, choiceSet) =>
                        acc.DefaultIfEmpty()
                            .SelectMany((chosen) => (choiceSet ?? Enumerable.Empty<T>()).DefaultIfEmpty().Select(choice => ConcatItem(chosen, choice)))
                );
                return result;
            }
    
            static void Main(string[] args)
            {
                var preCombination = new List<List<string>> { 
                    new List<string> {"1","2"}, 
                    new List<string> {"3"},
                    new List<string> {"4","5"},
                    null,
                    new List<string> {"6","7"},
                };
                var postCombination = helper2(preCombination);
    
                PrintOut(preCombination);
                Console.WriteLine();
                PrintOut(postCombination);
                Console.ReadLine();
            }
        }
    }
