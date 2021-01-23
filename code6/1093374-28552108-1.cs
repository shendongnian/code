    private static void Main(string[] args)
    {
        //Initial Data
        var lists = new List<RelatedList>
        {
            new RelatedList(new List<int> {1, 2, 3}),
            new RelatedList(new List<int> {2, 3}),
            new RelatedList(new List<int> {3, 4}),
            new RelatedList(new List<int> {3, 5}),
            new RelatedList(new List<int> {5, 6}),
            new RelatedList(new List<int> {7, 8}),
            new RelatedList(new List<int> {7, 9})
        };
        //Find "links" between the data
        foreach (var list in lists) 
            foreach (var other in lists) 
                foreach (var element in other.Data) 
                    if (!list.RelatedLists.Contains(other) && list.Data.Contains(element))
                        list.RelatedLists.Add(other);
        var results = new List<List<int>>();
        results.Add(new List<int>());
        //Process these links into lists of the linked data
        for (var i = 0; i < lists.Count; i++)
        {
            var list = lists[i];
            if (i == 0)
                results[results.Count - 1].AddRange(list.Data);
            else
            {
                var prev = lists[i - 1];
                if (!list.RelatedLists.Contains(prev)) //If this list is not related to anything further
                {
                    results.Add(new List<int>());
                    results[results.Count - 1].AddRange(list.Data);
                }
                else
                    results[results.Count - 1].AddRange(list.Data);
            }
        }
        //Remove repeated values
        for (var j = 0; j < results.Count; j++)
        {
            results[j] = results[j].Distinct().ToList();
        }
        //Print them out! You may use the data of `results` 
        for (var i = 0; i < results.Count; i++)
        {
            var result = results[i];
            Console.WriteLine("List " + (i + 1));
            foreach (var element in result)
                Console.WriteLine(element);
        }
        Console.ReadLine();
    }
    public class RelatedList
    {
        public List<int> Data { get; set; }
        public List<RelatedList> RelatedLists { get; set; }
        public RelatedList(List<int> data)
        {
            RelatedLists = new List<RelatedList>();
            Data = data;
        }
    }
