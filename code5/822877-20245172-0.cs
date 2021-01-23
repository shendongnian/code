    public class MainViewModel {
        public MainViewModel()
        {
        	CommandOne = new RelayCommand<string>(executeCommandOne);
        	CommandTwo = new RelayCommand(executeCommandTwo);
        }
    
        public RelayCommand<string> CommandOne { get; set; }
    
        public RelayCommand CommandTwo { get; set; }
    
        private void executeCommandOne(string param)
        {
        	//Reusable code with param
        }
    
        private void executeCommandTwo()
        {
        	//Reusable code without param
        }
    }
