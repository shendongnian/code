    int eatenAppleCount = 0;
    
    public MainPage()
    {
       CollisionDetect(ref eatenAppleCount);
       score.Content = "Score" + " " + Convert.ToString(eatenAppleCount);   
    }
    
    protected void CollisionDetect(ref eatenAppleCount)
    {
        for (int indx = myapples.Count - 1; indx >= 0; indx--)
        {
             myapples[indx].Update(LayoutRoot);
             bool collided = DetectCollision(myapples[indx], myPig);
             if (collided)
             {
                 eatenAppleCount ++;
                 RemoveApple(myapples[indx]);
             }
         }        
    }
