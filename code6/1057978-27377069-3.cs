    private async void GetEmployeeList()
    {
       await EmployeeController.GetAllEmployees().ContinueWith(r =>
       {
           _employees = (r.Result);
           EmployeeListBox.ItemsSource = _employees;
       },
       TaskScheduler.FromCurrentSynchronizationContext());
    }
