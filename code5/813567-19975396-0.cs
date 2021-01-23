    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
       if (starterRight.SelectedIndex == 0)
       {
          //Starter is off
          eng2Start.Value = 0;
       }
    
       if (starterRight.SelectedIndex == 1)
       {
          //starter is on 
    
          starterRight.enable = false;
    
          StopWatch sw = new StopWatch();      
          
          sw.Start();
          eng2Start.Value = 1;
          
          
          if (eng2Tourqe >= 6000)
          {
             //open fuel valve
             // set Hot Start counter to 0
          }
          else 
          {
             //ensure fuel valve stays closed
             // set Hot Start counter to x+1
          }
     
          if (sw.ElapsedMilliseconds <= 10000)
          {
             do
             {
                 //Dummy Loop
             }
             while (sw.ElapsedMilliseconds > 10000)
             sw.Stop(); 
          }
          else
          {
              // set selected index back to 0
              sw.Stop();
              starterRight.Enabled = true;
              (starterRight.SelectedIndex == 0)
          }
    
       }
    }
