    public Wave CurrentWave // Get the wave at the front of the queue
    {    
        get 
        { 
           if (waves.Count >= 1)
           {
              return waves.Peek(); 
           }
           else
           {
              return null;
           }
        }
    }
    
