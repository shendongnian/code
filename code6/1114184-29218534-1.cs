    for (int i = 0; i < enemies.Count; i++)
    {
        for (int j = i + 1; j < enemies.Count; j++)
        {
            if (enemies[i].collisionBox.IntersectsWith(enemies[j].collisionBox))
                System.Console.WriteLine("Collision Detected");
        }
    }   
