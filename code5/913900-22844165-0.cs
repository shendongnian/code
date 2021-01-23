    public String getRoomName(uint id)
    {
      if (_rooms.ContainsKey(id))
      {
        return _rooms[id].Name;
      }
      else
      {
        return ""; // Have an empty string to catch exceptions (this part isn't necessary but it could be helpful if you don't know that the room exists)
      }
    }
