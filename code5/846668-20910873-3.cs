    List<IGameEntity> entities = new List<IGameEntity>()
    {
        new Actor(), 
        new Building(), 
        new Policeman(), 
        new Fireman(), 
        new Fireman()
    };
    foreach (IGameEntity entity in entities)
    {
        entity.CollidesWith();
        entity.OnClick();
        entity.DoActing();
    }
