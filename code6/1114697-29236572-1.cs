    private void event1(object sender, EventArgs e)
    {
         if(Method1())
         {
          e.cancel;
          return;
         }
        else
        {
            if(Event2 != null)
         { Event2(this, new EventArgs());}
            if(Event3 != null)
         {Event3(this, new EventArgs());}
        }
    }
    private void event2(object sender, EventArgs e)
    {
     // your stuff    
    }
    private void event3(object sender, EventArgs e)
    {
        //your stuff
    }
    private bool Method1()
    {
         if(Your_condition_is_Matched)
         {
           return true;
           
         }
      return false;
    }
