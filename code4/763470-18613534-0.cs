    Person[] peopleInvited = ....; // Avoid copying this, we are not modifying it
    public void AssignToTable(int invited, SeatingArrangements tables)
    {
      if(!tables.HasRoom || invited == peopleInvited.Length)
        // Do what? Print the seating?
      else
      {
        var personToSeat = peopleInvited[invited];
        foreach (var possibleSeating in tables.GetEmptyChairs()) 
        {
          // Add one person to a table somewhere, but don't modify tables
          var newArrangments = Assign(possibleSeating, personToSeat, tables) 
          AssignToTable(invited + 1, newArrangements);
        }
      }
    }
