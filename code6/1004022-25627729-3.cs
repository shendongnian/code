        public class ViewModel
    {
        public ObservableCollection<Room> Rooms { get; set; }
        public ViewModel()
        {
            Rooms = new ObservableCollection<Room>() 
            {
                new Room(){Master="I",IsNeedPassword=false},
                new Room(){Master="I",IsNeedPassword=true},
                new Room(){Master="j",IsNeedPassword=false},
                new Room(){Master="k",IsNeedPassword=true}
            };
        }
    }
