    // game object types ...
    enum _game_object_type_enum
     {
     _game_object_type_none=0,
     _game_object_type_wall,
     _game_object_type_brick1,
     _game_object_type_brick2,
     _game_object_type_brick3,
     _game_object_type_bomb,
     _game_object_type_joker1,
     _game_object_type_joker2,
     ...
     };
    
    // game object class
    class game_object
     {
    public;
     int type;                // type of object  
     float x,y,vx,vy,hx,hy; // position,speed,half size of rectangle
     void update(float dt); // this call periodicaly in some timer updates positions,... and call events, dt is time passed
     void draw(); // can add some rendering device context ...
     };
    
    // whole game class holds the game world/board/map and player(s) ...
    class game_board
     {
    public;
     game_object *go; int gos; // list of all objects in game
     void update(float dt) { for (int i=0;i<gos;i++) go[i].update(dt); }
     void draw() { for (int i=0;i<gos;i++) go[i].draw(); }
     }
