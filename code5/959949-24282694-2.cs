    // Get the rooms with OCCUPANCY value equal to 2.
    rooms = rooms.Where(x=>x.OCCUPANCY==2);
    // Iterate through the selected rooms.
    foreach(var room in rooms)
    {
        // Build a list of integers based on the room's list age.
        List<int> currentListAge = room.ChildAges.Split(',').Select(int.Parse).ToList();
        
        // Concat the currentListAge with the listAge, order the resulting list and
        // then build a comma separated value list.
        room.ChildAges = String.Join(",", currentListAge.Concat(listAge)
                                                        .OrderBy(x=>x)
                                                        .Select(x=>x.ToString())
                                                        .ToList());
    }
                 
