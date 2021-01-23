    public class MainWindowDesignFactory
    {
        public static IMainWindow ViewModel
        {
            get
            {
                return new MainWindowDesignFactory().Create();
            }
        }
        public IMainWindow Create()
        {
            var vm = new MainWindowDesign();
            vm.Customers = new ObservableCollection<ICustomer>()
            {
                new CustomerDesign() { Name = "Charly Sparow" },
                new CustomerDesign() { Name = "Jacky Chan" },
                new CustomerDesign() { Name = "Dora Exploring" }
            };
            return vm;
        }
        private class MainWindowDesign : IMainWindow
        {
            public ObservableCollection<ICustomer> Customers { get; set; }
        }
        private class CustomerDesign : ICustomer
        {
            public string Name { get; set; }
        }
    }
