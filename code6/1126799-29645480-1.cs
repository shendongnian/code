    public class MainViewModel
        {
            public MainViewModel()
            {
                //set some properties
                Title = "Main view";
            }
            public static string GetMainViewModelString()
            {
                var mainViewModel = new MainViewModel();
                return mainViewModel.GetString();
            }
            public string GetString()
            {
                /*your code*/
            }
        }
