    private PlayerTimer_Tick(object sender, EventArgs e)
    {
         if (GlobalVar.Status != "alive")
             return; // you can also stop timer in this case
    
         if (GlobalVar.Direction == "up")
         {
             if (GlobalVar.Column == 0)
                 died();
             else
                 moveupp(GlobalVar.Row, GlobalVar.Column, "player");  
         }
    }
