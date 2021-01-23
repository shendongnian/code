    UI.Controls.Generic.User LoggedInUser = UsersStackPanel.Children
        .OfType<UI.Controls.Generic.User>()
        .FirstOrDefault(e => e.Employee.EmpRef == employee.EmpRef);
    if (LoggedInUser != null)
    {
        // some DB stuff here
        UsersStackPanel.Children.Remove(LoggedInUser);
    }
