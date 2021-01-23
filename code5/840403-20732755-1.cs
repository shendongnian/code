    public class Book : Node
    {
        public override void SetParent(INode node)
        {
            throw new InvalidOperationException();
        }
        public string Title { get; set; }
    }
