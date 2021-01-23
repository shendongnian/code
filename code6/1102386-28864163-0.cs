    UIBarButtonItem * newButton;
    public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            newButton =  new UIBarButtonItem(UIBarButtonSystemItem.Action, (sender,args) => {
                    UIAlertView alert = new UIAlertView("Add link!", "Enter the ID of the person you want to be linked with:", null, "Cancel", "OK");
                    alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
                    alert.Show ();
                })
            this.NavigationItem.SetRightBarButtonItem(newButton, true);
        }
