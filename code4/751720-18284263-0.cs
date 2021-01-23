    for (int i = 0; i < boxlist.Count; i++)
    {
        if (player.collisionRect.Intersects(boxlist[i].collisionRect))
        {
            ground.Y = boxlist[i].collisionRect.Y;
            player.setPositionY(0);
        }
        else
        {
            ground.Y = 640;
        }
    }
