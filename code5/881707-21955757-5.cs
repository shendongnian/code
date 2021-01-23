    var vm = new ViewModel();
    DataContext = vm;
    vm.ImageItems.Add(
        new ImageItem
        {
            Source = @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
            Left = 100,
            Top = 50
        });
    vm.ImageItems.Add(
        new ImageItem
        {
            Source = @"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg",
            Left = 200,
            Top = 100
        });
