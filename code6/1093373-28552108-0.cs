    private static void Main(string[] args)
    {
        var lists = new List<RelatedList>
        {
            new RelatedList(new List<int> {1, 2, 3}),
            new RelatedList(new List<int> {2, 3}),
            new RelatedList(new List<int> {3, 5}),
            new RelatedList(new List<int> {5, 6}),
            new RelatedList(new List<int> {7, 8}),
            new RelatedList(new List<int> {7, 9}),
        };
        foreach (var list in lists)
        {
            foreach (var other in lists)
            {
                foreach (var element in other.Data)
                {
                    if (!list.RelatedLists.Contains(other) && list.Data.Contains(element)))
                        list.RelatedLists.Add(other);
                }
            }
        }
    }
    public class RelatedList
    {
        public List<int> Data;
        public List<RelatedList> RelatedLists;
        public RelatedList(List<int> data)
        {
            Data = data;
        }
    }
