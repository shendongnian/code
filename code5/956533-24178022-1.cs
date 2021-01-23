    foreach(ICollidable obj1 in iCollidableList)
    {
        foreach(ICollidable obj2 in iCollidableList)
        {
            if(obj1 != obj2 && HitBoxesIntersect(obj1, obj2))
            {
               obj1.HandleCollision(obj2);
               obj2.HandleCollision(obj1);
            }
        }
    }
