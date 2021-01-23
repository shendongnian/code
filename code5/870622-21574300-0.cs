    public class AnotherViewModel : ViewModelBase
    {
        public AnotherViewModel()
        {
            DoWork = new Command(OnDoWorkExecute);
        }
    
        /// <summary>
        /// Gets the DoWork command.
        /// </summary>
        public Command DoWork { get; private set; }
    
        /// <summary>
        /// Method to invoke when the DoWork command is executed.
        /// </summary>
        private void OnDoWorkExecute()
        {
            Test("1", "2");
        }
    
        public async Task<int> Test(string login, string password)
        {
            var a = await Task<int>.Factory.StartNew(() =>
            {
                var someType = TypeFactory.Default.CreateInstance<int>();
                return 42;
            });
    
            a++;
            return a;
        }
    }
