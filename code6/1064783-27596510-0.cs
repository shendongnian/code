    public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
       {
           if (segue.Identifier == "LoginSegue")
           {
               var destCtrl = segue.DestinationViewController as LoginViewController;
               if (destCtrl != null)
               {
                   // pass in a reference to THIS view controller.
                   destCtrl.SetData(this);
               }
           }
           base.PrepareForSegue(segue, sender);
       }
