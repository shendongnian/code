    public class Track
    {
        public int      Id       { get; set; }
        public string   Name     { get; set; }
        public TimeSpan Duration { get; set; }
        public override string ToString()
        {
            return String.Format("{0}. {1} ({2:mm'm'ss's'})",
                 this.Id, this.Name, DateTime.MinValue.Add(this.Duration));
        }
    }
    static void Main(string[] args)
    {
        var tracks = new[]
        { 
            new Track { Id = 1, Name = "Song #1", Duration = TimeSpan.Parse("00:01:30") /* 01m30s */ },
            new Track { Id = 2, Name = "Song #2", Duration = TimeSpan.FromSeconds(45)   /* 00m45s */ },
            new Track { Id = 3, Name = "Song #3", Duration = new TimeSpan(0, 2, 45)     /* 02m45s */ }
        };
        foreach (var track in tracks)
            Console.WriteLine(track);
    }
