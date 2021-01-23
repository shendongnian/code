     Public overrides sub Update(Gametime gametime) 
       foreach (IUpdating i in entityList)
          i.CollideWith(testCollistion(i))
          i.Update(gameTime);
         base.Update(gameTime);
     end sub
     
     Function TestCollision(myentity as Entity) as Entity
      //test collision as per the tutorial 
      //return nothing if it doesnt collide, or the colliding entity if is does
     end function
