     void SysTray_MouseClick(object sender, EventArge e)
         {
            click=true;
            System.Threading.Thread.Sleep(400);//It should be about 300 but for sure.
            if(click)
              {
                //codes go here
              }
         }
     void Systray_DoubleClick(object sender , EventArge e)
         {
            click=false; // If it is doubleclick cancel the single click event.
            //codes go here.
         }
