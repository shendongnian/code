    ViewModel MyViewModel = this.DataContext as ViewModel;
    MyViewModel.MyCollection = new ObservableCollection<Person>();
    MyViewModel.MyCollection.Add(new Person()
    {
        Age = 22,
        Name = "Nick",
    });
