    public abstract class ContentItem 
    {
        public string Title { get; set; }
        public string AnotherTitle { get; set; }
    }
    public class Channel : ContentItem
    {
        public string AnotherTitle { get; set; }
    }
    
    private static void Main(string[] args)
    {
        var channels = new List<Channel>();
        for (int i = 0; i < 3000; i++)
        {
            channels.Add(new Channel(){Title = i.ToString(), AnotherTitle = i.ToString()});
        }
        int iterations = 100000;
        System.Diagnostics.Stopwatch watch;
        var difs = new List<int>();
        int rounds = 10;
        for (int k = 0; k < rounds ; k++)
        {
            watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                var channel = channels.Find(item => item.Title == "2345");
            }
            watch.Stop();
            long timerValue = watch.ElapsedMilliseconds;
            watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                var channel = channels.Find(item => item.AnotherTitle == "2345");
            }
            watch.Stop();
            difs.Add((int)(timerValue - watch.ElapsedMilliseconds));
        }
        Console.WriteLine("result middle dif " + difs.Sum()/rounds);
    }
