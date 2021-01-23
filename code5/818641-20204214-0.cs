    ViewModel.WeakSubscribe(() => ViewModel.IsLoading, (sender, args) =>
    {
    	if (ViewModel.IsLoading)
    	{
    		ShowLoadingDialog("Loading Resource");
    	}
    	else
    	{
    		DismissLoadingDialog();
    	}
    });
    
    void ShowLoadingDialog(string text)
    {
    	DismissLoadingDialog();
    	BTProgressHUD.Show(text, -1, BTProgressHUD.MaskType.Black);
    }
    
    void DismissLoadingDialog()
    {
    	if (BTProgressHUD.IsVisible)
    		BTProgressHUD.Dismiss();
    }
