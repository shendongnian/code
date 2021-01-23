        public class VMFactory
        {
            public async Task<MainViewModel> GetVM()
            {
                MainViewModel vm = new MainViewModel();
                await vm.LongOperation();
                return vm;
            }
        }
        public class MainViewModel
        {
            public MainViewModel()
            {
                //set some properties
                Title = "Main view";
            }
            public async Task LongOperation()
            {
                (...)
            }
        }
