    void OnCollisionFX(game_object o1,game_object o2)
     {
     // do something ...
     }
    
    void (*OnCollision)(game_object o1,game_object o2)=OnCollisionFX;
