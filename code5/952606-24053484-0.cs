    private async void Next_AppBarIconButton_Click(object sender, EventArgs e) 
    {
        LogInViewModel view_Model = new LogInViewModel();  // You are creating new instace...How would you expact this new instance will get the values from binded instace!
        var tuple = (Tuple<bool, string>)await view_Model.Get_Verification_Code();
    }
