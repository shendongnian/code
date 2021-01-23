    public class Foo
    {
        public IEnumerable<string> Sequence { get; set; }
        public IEnumerable<string> IteratorBlock()
        {
            Console.WriteLine("I'm iterating Sequence in an iterator block");
            foreach (string s in Sequence)
                yield return s;
        }
        public IEnumerable<string> NoIteratorBlock()
        {
            Console.WriteLine("I'm iterating Sequence without an iterator block");
            return Sequence;
        }
    }
