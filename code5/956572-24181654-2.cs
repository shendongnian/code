    public class Node
    {
        public int Value;
        public Node Parent;
        public List<int> ToList()
        {
            if(Parent == null)
            {
                return new List<int> { Value };
            }
            var result = Parent.ToList();
            result.Add(Value);
            return result;
        }
    }
