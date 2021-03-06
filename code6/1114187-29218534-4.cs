    foreach (EnemyClass enemy in enemies)
    {
        if (enemy.position.X < myPlayer.position.X - 10 && !enemy.stopMoving)
        {
            enemy.position.X += enemy.amountToMove;                   
        }
        if (enemy.position.X > myPlayer.position.X - 50 && !enemy.stopMoving)
        {
            enemy.position.X -= enemy.amountToMove;
        }
        enemy.Update(graphics.GraphicsDevice);
    } 
    for (int i = 0; i < enemies.Count; i++)
    {
        for (int j = i + 1; j < enemies.Count; j++)
        {
            if (enemies[i].collisionBox.Intersects(enemies[j].collisionBox))
            {
                System.Console.WriteLine("Collision Detected");
            }
        }
    }
