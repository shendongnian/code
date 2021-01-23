     private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
     {
        Day day = e.NewValue as Day;
        foreach (var item in day.Shifts)
        {
             ShiftControl ctrl = new ShiftControl();
            // here I somehow want to bind item.StartTime to ctrl.StartTime
             Binding myBinding = new Binding("StartTime");
             myBinding.Source = item;
             ctrl.SetBinding(ShiftControl.StartTimeProperty, myBinding);
           
             _shifts.Children.Add(ctrl);
     }
    }
