    // Create your bullets
    var bullets = new Bullets();
    
    // Create a raw/empty bullet with default properties 
    var newBullet1 = new Bullet();
    // Create bullet with some initialized properties
    var newBullet2 = new Bullet()
       {
          Angle = 35, 
          Position = 0, 
          Speed = 200
       };
    
    bullets.Add(newBullet1);
    bullets.Add(newBullet2);
