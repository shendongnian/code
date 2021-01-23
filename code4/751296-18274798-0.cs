    public class Part
    {
        public IEnumerable<Part> Children { get; set; }
        public int Count()
        {
            var stack = new Stack<Part>();
            stack.Push(this);
            int total = 0;
            while (stack.Any())
            {
                total++;
                foreach (var child in stack.Pop().Children)
                    stack.Push(child);
            }
            return total;
        }
    }
