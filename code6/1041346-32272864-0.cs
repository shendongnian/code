    public MainPage()
    {
      var vm = new MyViewModel();
      vm.GotoPage2Command = new RelayCommand(()=>{ Frame.Navigate(typeof(Page2)) });
      this.DataContext = vm;
    }
    
    <Button Command={Binding GoToPage2Command}>Go to Page 2</Button>
