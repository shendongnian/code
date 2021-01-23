    //make global declaration of a counter variable 
   
     int counter =60;    
        void OnTimerTick(Object sender, EventArgs args)
           {       
             counter --;
             if(counter<0)
             {
              newTimer.Stop();
              counter=60;
             }
            else
             {
              clock.Text =counter.ToString();
             }
           }
