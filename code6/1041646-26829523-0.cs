      public Air_Score Update(Air_Score myApp)
        {
            if (myApp != null)
            {
                var c = e.Air_Score.FirstOrDefault(a => a.ID == myApp.ID);
                if (c != null)
                {
                    c.Score = myApp.Score;
    
                }
                e.SaveChanges();
            }
            return c;
        }
