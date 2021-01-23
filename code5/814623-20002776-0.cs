    public void update(Rectangle rect)
    {
        //System.Console.WriteLine(playerRect.X, playerRect.Y);    
        if (collision.boundingBoxCollisionCheck(rect.X, rect.Y, rect.Width, rect.Height))
        {
            System.Console.WriteLine("COLLISION!!!!! at x: " + tileRect.X + "y: " + tileRect.Y );                  
        }  
    }
