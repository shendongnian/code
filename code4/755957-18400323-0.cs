    List<IUnit> army = new List<IUnit>(); 
    Infantry infantry = new Infantry();    
    for(int i = 0; i < 10; i++)
    {
        // adds same instance each time        
        army.Add(infantry);
    }
