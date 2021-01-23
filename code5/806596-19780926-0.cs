    public void dothis()
    {
        do
        {
            if (intHour < 23)
                intHour = intHour += intStep;     
       
            lblTimerHour.Invoke((MethodInvoker)delegate {   
                //Update the label from the GUI thread    
                lblTimerHour.Text = intHour.ToString("00");
            });
            //Pause 1 sec. Won't freeze the gui since it's in another thread
            System.Tread.Sleep(1000);
        }while(true); //Thread is killed on mouse up
    }
