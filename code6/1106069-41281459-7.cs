    public class LoginViewModel : NavigableViewModel
        {
            private string _helloWorld;
            public string HelloWorld
            {
                get
                {
                    return _helloWorld;
                }
                set
                {
                    _helloWorld = value;
                    RaisePropertyChanged(() => HelloWorld);
                }
            }
    
            public LoginViewModel()
            {
                HelloWorld = "Hello World";
            }
    
            public override void OnNavigatedTo(object parameter = null)
            {
              // whatever you want to happen when you enter this page/viewModel
            }
    
            public override void OnNavigatingTo(object parameter = null)
            {
                // whatever you want to happen when you leave this page/viewmodel
            }
        }
