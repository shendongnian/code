    List<IGameEntity> Entities = new List<IGameEntity>();
    
    Actor a1 = new PoliceMan();
    Building b1 = new PoliceStation();
    
    Entities.Add(a1);
    Entities.Add(b1);
    
    foreach(IGameEntity ent in Entities)
    {
        if (ent.CollidesWith(something))
        {
            ent.OnClick();
    
            ent.Do();
        }
    }
