    int numberHorses = 3; //or some user input
    Random r = new Random();
    List<Horse> unassignedHorses = retriveUnassignedHorses();
    List<Horse> assignedHorses = new List<Horse>();
    do
    {
      int rIint = r.Next(0, unnasignedHorses.Count);
      if(!assignedHorses.Contains(unassignedHorses[rInt]))
      {
        assignedHorses.Add(unassignedHorses[rInt]);
      }
    } (while assignedHorses.Count != numberHorses);
