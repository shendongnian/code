    ObservableCollection<VacationItemViewModel>  myPivotItems = new ObservableCollection<VacationItemViewModel>() 
    {
           new VacationItemViewModel(){Name="Test1", Value="test1", Header="First Item"},
           new VacationItemViewModel(){Name="Test1", Value="test1", Header="Second Item"}
        };
    foreach (var item in myPivotItems)
    {
        item.VacationItemViewModelItems = new ObservableCollection<VacationItemViewModel>()
            {
                new VacationItemViewModel(){Name="Test1", Value="test1"},
                new VacationItemViewModel(){Name="Test1", Value="test1"}
            };
    }
    this.myPivot.DataContext = myPivotItems;
