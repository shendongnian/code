            public List<Room> getMatchingRooms(string idToMatch)
            {
                List<Room> matchingRooms = new List<Room>();
                foreach (Room r in db.Room)
                {           
                    if (r.hotelId == idToMatch)
                    {
                        matchingRooms.Add(r);
                    }
                }
                return matchingRooms;
            }
