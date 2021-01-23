    public override void OnBackPressed()
    {
        if (alert !=null){
           if(alert.IsShowing){
              alert.Dismiss ();
            }else{
              base.OnBackPressed();
            }
         }else{
            base.OnBackPressed();
         }
    }
