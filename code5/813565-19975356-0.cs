        if (starterRight.SelectedIndex == 1)
           {
              //starter is on 
              //Start Timer
             timer1.Enabled=true;
        
           }
        
                //in timer tick Event write the following:
                private void timer1_Tick(object sender, EventArgs e)
                {
                timer1.Enabled=false;
               //Statements to start aircraft 
                }
