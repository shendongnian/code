    public static readonly DependencyProperty RoomProperty =
        DependencyProperty.Register(
            "Room", typeof(RoomData), typeof(RoomAndPersonsAccommodationItem),
            new FrameworkPropertyMetadata(null)); 
    public RoomData Room
    {
         get { return (RoomData)GetValue(RoomProperty); }
         set { SetValue(RoomProperty, value); }
    }
