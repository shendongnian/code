    public void DoSomething()
    {
        // Create the list
        List<Invaders> invadersList = new List<Invaders>();
                
        // Add some objects
        invadersList.Add(new Invader());
        invadersList.Add(new Invader());
        invadersList.Add(new Invader());
        invadersList.Add(new Invader());
    
        // Insert a new object at position 2
        invadersList.Insert(2, new Invader());
    }
