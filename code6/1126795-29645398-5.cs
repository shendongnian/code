        public class VMRepository
        {
            public async Task LongOperation()
            {
                (...)
            }
            public async Task<MainViewModel> GetVM()
            {
                MainViewModel vm = new MainViewModel();
                vm.DataWhichTakesAlongTime  = await LongOperation();
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
            public object DataWhichTakesAlongTime { get; set; }
        }
