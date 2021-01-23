    bool collision = false;
    void CheckCollision(){
        colliding = /* Colliding() */;
        if(colliding  && !collision){
            collision = true;      
            //Manipulate directions, locations, etc.   
        }        
        else if(!colliding ){ //No collision
            collision = false;
        }
    }
    
    bool Colliding(){
        return colliding;
    }
