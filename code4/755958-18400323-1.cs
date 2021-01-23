    List<IUnit> army = new List<IUnit>(); 
    
    for(int i = 0; i < 10; i++)
    {
        // create new instance each time
        Infantry infantry = new Infantry();
        army.Add(infantry);
    }
