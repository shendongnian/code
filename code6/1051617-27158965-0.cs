    {
        //somewhere in MainWindowViewModel
        CustomerViewModel cvm = new CustomerViewModel();
        cvm.CheckMenuItemClicked += cvm_CheckMenuItemClicked;
    }
    void cvm_CheckMenuItemClicked(object sender, EventArgs e)
    {
        //logic to check the check box
    }
