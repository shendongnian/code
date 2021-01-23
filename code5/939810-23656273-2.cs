    bool AllowUsersScrolling;
    private void usersCombobox_MouseLeave(object sender, System.EventArgs e) 
    {
        AllowUsersScrolling = false;
    }
    private void usersCombobox_MouseEnter(object sender, System.EventArgs e) 
    {
        AllowUsersScrolling = true;
    }
    private void usersCombobox_MouseWheel(object sender, MouseEventArgs e)
    {
        if(!AllowUsersScrolling)
            ((HandledMouseEventArgs)e).Handled = true;
    }
