     public void Update(GameTime gameTime)
     {
       drawEnemyRectangle.Y = enemyYPosition / 2;
       drawEnemyRectangle.X = enemyXPosition;
       
       if (enemyXPosition > 0) 
       {
          enemyXPosition -= 50;
       } 
       else 
       {
         enemyXPosition = 1200;
       }
     }
