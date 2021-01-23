    // former IControl, renamed to avoid confusing with view layer
    public interface ICanvasItem
    {
        object Content { get; set; }
        double X { get; set; }
        double Y { get; set; }
    }
    
    public class MyButton : ICanvasItem, INotifyPropertyChanged { /* ... */}
    public class MyLabel : ICanvasItem, INotifyPropertyChanged { /* ... */}
