    public class ChartItemModel
    {
        public string Title { get; set; }
        
        public double Value { get; set; }
        
        public Brush Color { get; set; }
    }
    var chartItems = new [] 
    { 
        new ChartItem { Title = "Item1", Value = 25, Color = (Brush)Resources["BlueBrush"] }, 
        new ChartItem { Title = "Item2", Value = 75, Color = (Brush)Resources["YellowBrush"] }
        // other items, the Color property of which doesn't have a red or green brush
    };
    // binding
