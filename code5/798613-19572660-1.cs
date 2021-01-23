    public void Randomize()
    {
       int random = rand.Next(1,WIDTH);  
       thisObstacle = new Obstacle(); //Blah, make your obstacle.
       thisObstacle.rect = new Rectangle(random, Y,WIDTH, HEIGHT);
       
       foreach (Obstacle obstacle in obstacles)
       {
            //If less than 100 pixels distance, make the obstacle somewhere else
            if (GetDistance(thisObstacle.rect, obstacle.rect) < 100)
            {
                 Randomize();
                 return;
            }
       }
       //If we didn't get near an obstacle, place it
            //Do whatever you do
    }
    private static double GetDistance(Rectangle point1, Rectangle point2)
    {
         //Get distance by using the pythagorean theorem
         double a = (double)(point2.X - point1.X);
         double b = (double)(point2.Y - point1.Y);
         return Math.Sqrt(a * a + b * b);
    }
