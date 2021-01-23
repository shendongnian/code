    class ImageHandler : INotifyPropertyChanged
    {
        List<Direction> directions = new List<Direction>();
        public List<Direction> Directions { get { return directions; } }
        // ...
     
        public ImageHandler()
        {
           Directions.Add(new Direction {DisplayName = " N" });
           Directions.Add(new Direction {DisplayName = "NW" });
           Directions.Add(new Direction {DisplayName = " W" });
           //.. Etc
    
           Directions.ForEach(x => x.OnIsSelectedChanged = OnDirectionSelectionChanged);
        }
    
        private void OnDirectionSelectionChanged(Direction direction)
        {
           //.. Your logic here
        }
    }
