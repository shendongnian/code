    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var vm = (SecondPageViewModel)this.DataContext;
            if (vm!=null)
            {
                var temp = e.Parameter as MyObject;
                if (temp != null) 
                {
                     vm.MyObjectProperty = temp;
                }
            }
        }
