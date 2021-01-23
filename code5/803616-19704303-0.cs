    for(int i=0;i<Monster.Count(); i++)
    {
     var m = Monster.ElementAt(i);
     //Update
    if (m.health == 0)
    {
       Monster.Remove(m)
    }
    
    //Draw
    
    If (m.health > 0)
    {
    spriteBatch.Draw(m.texutre,m.pos,Color.White);
    }
    }
