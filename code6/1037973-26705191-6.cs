    aControl.MyControlClick += aControl_MyControlClick;
    // ...
    // This code is triggered when a MyUserControl is clicked
    void aControl_MyControlClick(MyUserControl ctl)
    {
        MessageBox.Show(ctl.ID);
    }
