    public override void ViewDidLoad ()
    {
        base.ViewDidLoad ();
        ShowAlertOnSelectCompletion(new CustomDialog());
    }
    private async void ShowAlertOnSelectCompletion(CustomDialog dialog)
    {
        var customType = await dialog.Select ();
        UIAlertView alert = new UIAlertView ("dialog later", "item select " + customType.code, null, null, "ok");
        alert.Show ();
    }
