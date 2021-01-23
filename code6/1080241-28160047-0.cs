    public class QuestionModel : INotifyPropertyChanged
    {
        private string[] _questions = new string[]
		{   
			"Question :\n What is OOPS?   \n\n Answer: \n  Object-oriented programming (OOP) is a programming paradigm based on the concept of objects which are data structures that contain data in the form of fields often known as attributes and code in the form of procedures often known as methods. There are a few principle concepts that form the foundation of object-oriented programming: 1- Object \n 2- Class \n 3- Abstraction \n 4- Polymorphism \n 5- Inheritance \n 6- Encapsulation \n 7- Overloading & OverRiding   ",
			"Question 2",
			"Question 3",
			"Question 4"
		};
        private int _selectedIndex = 0;
        public QuestionModel() {
            PrevCommand = new DelegateCommand(() => { 
                if(_selectedIndex > 0) {
                    _selectedIndex--;
                    selectedIndexChanged();
                }
            });
            NextCommand = new DelegateCommand(() => { 
                if(_selectedIndex < _questions.Length - 1) {
                    _selectedIndex++;
                    selectedIndexChanged();
                }
            });
        }
        private void selectedIndexChanged() {
            NotifyPropertyChanged("CurrentQuestion");
            NotifyPropertyChanged("QuestionText");
            NotifyPropertyChanged("IsNextEnabled");
            NotifyPropertyChanged("IsPrevEnabled");
        }
        
        public int CurrentQuestion
        {
            get { return _selectedIndex + 1; }
        }
        public string QuestionText
        {
            get { return _questions[_selectedIndex]; }
        }
        public bool IsNextEnabled
        {
            get { return _selectedIndex < _questions.Length - 1; }
        }
        public bool IsPreviousEnabled
        {
           get { return _selectedIndex > 0; }
        }
		private ICommand _nextCommand;
		public ICommand NextCommand
		{
			get { return _nextCommand; }
			set
			{
				_nextCommand = value;
				NotifyPropertyChanged();
			}
		}
		private ICommand _prevCommand;
		public ICommand PrevCommand
		{
			get { return _prevCommand; }
			set
			{
				_prevCommand = value;
				NotifyPropertyChanged();
			}
		}
        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;
        public DelegateCommand(Action action)
        {
            _action = action;
        }
    
        public void Execute(object parameter)
        {
            _action();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
    #pragma warning disable 67
        public event EventHandler CanExecuteChanged;
    #pragma warning restore 67
    }
