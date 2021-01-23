    public interface IMyInterface<T>
    {
        T MergeWith(params T[] others);
        T InnerElem { get; }
    }
    public class C : IMyInterface<int>
    {
        public C(int elem)
        {
            InnerElem = elem;
        }
        public int MergeWith(params int[] others)
        {
            return others.Sum() + InnerElem;
        }
        public int InnerElem { get; private set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var items = Enumerable.Range(0, 12).Select(x => new C(x));
            foreach (var item in Package(items, 4, 20))
            {
                Console.WriteLine(item);
            }
        }
        static IEnumerable<T> Package<T>(
            IEnumerable<IMyInterface<T>> sequence, 
            int n, T def)
        {
            return sequence
                .Select((x, ix) => new { item = x, ix })
                .GroupBy(x => x.ix / (n+1))
                .Select(x =>
                {
                    var first = x.First().item;
                    var others = x.Skip(1).Select(z => z.item.InnerElem);
                    var missing = n - others.Count();
                    var missingItems = Enumerable.Range(0, missing).Select(_ => def);
                    return first.MergeWith(others.Concat(missingItems).ToArray());
                });
        }
    }
