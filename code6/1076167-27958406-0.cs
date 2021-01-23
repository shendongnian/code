    public class Room
	{
		public string RoomName { get; set; }
	}
	public class RoomWrapper
	{
		public Room Room { get; set; }
	}
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			this.DataContext = this; 
        }
	    public List<RoomWrapper> RoomWrappers
	    {
		    get
		    {
			    var list = new List<RoomWrapper>();
			    for (int i = 0; i < 10; i++)
			    {
					list.Add(new RoomWrapper { Room = new Room { RoomName = "Room " + i } });    
			    }
				
			    return list;
		    }
	    }
	    private Room selectedRoom;
	    public Room SelectedRoom
	    {
		    get { return selectedRoom; }
		    set
		    {
			    selectedRoom = value;
		    }
	    }
