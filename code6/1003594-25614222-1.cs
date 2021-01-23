    public void UpdateBullets()
    {       
        //For each bullet in our bulletlist: Update the movment and if the bulet hits side of the screen remove it form the list
        foreach(Bullet bullet in bulletList)
        {
            //set movment for bullet
            bullet.position.X += bullet.speed;
            bullet.position.Y += bullet.Ychange; 
            // Above will change at a constant value
            //if bullet hits side of screen, then make it visible to false
            if (bullet.position.X >= 800)
                bullet.isVisible = false;
        }
        //Go thru bulletList and see if any of the bullets are not visible, if they aren't  then remove bullet form bullet list
        for (int i = 0; i < bulletList.Count; i++)
        {
            if(!bulletList[i].isVisible)
            {
                bulletList.RemoveAt(i);
                i--;
            }
        }         
    }
