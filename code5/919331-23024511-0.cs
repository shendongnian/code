    short afk = 0;
    
    onTimer_tick{
       afk += 1;
       
       if(afk == 500){
          timerInterval = 0; //(stop counting) 
       }
    
    }
    
    onMouseMove or KeyPress //(outside the frame, in any application){
        timerInterval = 1000; ///every 1 second restart
        afk = 0;
    }
