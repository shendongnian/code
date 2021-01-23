    public RoomViewModel GetRooms(int someParameter)
    {
        RoomViewModel result = new RoomViewModel();
        result.Rooms = RoomHelper.Something(someParameter);
        ...
        return result;
    }
