    public class GridSplitterViewModel : ITrackItem
    {
      // Code omitted...
    }
    
    public class TrackViewModel : ITrackItem
    {
      // Code omitted...
    }
    
    public interface ITrackItem
    {
      // Whatever properties that you may need.
      public Type ItemType { get; }
    }
    
    public class MainViewModel
    {
       public MainViewModel()
       {
         // Made it simple but the idea is here..
         Tracks = new ObservableCollection<ITrackItem>(GetSomethingFromTheDatabaseMaybe());
    	 Tracks.Insert(1, new GridSplitterViewModel());
    	 Tracks.Insert(3, new GridSplitterViewModel());
       }
     
      // Rest of code omitted
    }
