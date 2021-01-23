    public class Options
        {
            public Options()
            {
            }
            public Options(List<int> d,string approach)
            {
                if (approach == "straight")
                {
                    begin = d.Min();
                    end = d.Max();
                }
                else if (approach == "curved")
                {
                    choosen = d.Select(cc => cc).ToArray();
                }
            }
    
            public int? begin { get; set; }
            public int? end { get; set; }
            public int[] choosen { get; set; }
        }
