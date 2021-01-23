    public class WordCount
    {
        public string Word { get; set; }
        public int CharCount { get; set; }
    }
    public List<WordCount> SortList(List<WordCount> list)
    {
        WordCount temp;
        for (int i = list.Count -1; i >= 1; i--)
        {
            for (int j = 0; j < list.Count -1; j++)
            {
                if(list[j].CharCount < list[j+1].CharCount)
                {
                    temp = list[j];
                    list[j] = list[j+1];
                    list[j+1] = temp;
                }
            }
        }
        return list;
    }
    public List<WordCount> TakeNItems(int n, List<WordCount> list)
    {
        List<WordCount> temp = new List<WordCount>();
        for(int i = 0; i < n; i++)
            temp.Add(list[i]);
        return temp;
    }
    //Usage:
    var result = SortList(counts);
    result = TakeNItems(20, result);
