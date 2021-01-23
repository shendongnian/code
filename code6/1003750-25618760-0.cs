    public class Data
    {
        public string Name {get; set;}
    }
    var keys = new[]{"1", "15", "13", "16"};
    var random = new Random();
	
    var data = Enumerable.Range(1, 100)
        .Select( _ => new Data
        {
            Name = random.Next(24).ToString()
        });
    var keys = new[]{"1", "15", "13", "16"};
