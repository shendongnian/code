    for (int i = bullets.Count - 1; i >= 0; i--)
    {
        bullets[i].Update(delta);   
    
        //Bullets being destroyed upon leaving 
        if (bullets[i].position.Y < 0)
        {
            bullets[i].Delete = true;
        }
    
        foreach (Enemy enemy in enemies)
        {
            if (bullets[i].boundingBox.Intersects(enemy.boundingBox)) 
            { 
                bullets[i].Delete = true;
            }
        }
    }
    List<Bullet> newBullets = new List<Bullet>();
    
    foreach (Bullet bullet in bullets)
    {
        if (bullet.Delete == false)
    	{
    	    newBullets.Add(bullet);
    	}
    }
    bullets = newBullets;
