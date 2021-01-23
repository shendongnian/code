       for(int i=0; i<enemies.Count();i++){
           spritebatch.Draw(enemy, enemies[i].Rect, srcrect2, Color.White);
        }
    class Enemy{
       public Rectangle Rect{get;set;}
       public bool defeated{get;set;}
       public int Health{get;set;}
    
       public Enemy(Rectangle rect){
          Rect = rect;
          Health = 100;
          defeated = false;
       }
    
    }
