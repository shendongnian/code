     void SysTray_MouseClick(object sender, EventArge e)
         {
            click=true;
            System.Threading.Thread.Sleep(300);//Test with this amount!!
            if(click)
              {
                //codes go here
              }
         }
     void Systray_DoubleClick(object sender , EventArge e)
         {
            System.Threading.Thread.Sleep(20);//This too!
            click=false; // If it is doubleclick cancel the single click event.
            //codes go here.
         }
