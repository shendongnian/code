    public class SomePageViewModel : INotifyPropertyChanged
    {
        public int Answer
        {
            get { return _answer; }
            set
            {
                if (_answer != value)
                {
                    _answer = value;
                    OnPropertyChanged("Answer");
                }
            }
        }
        public int Question1
        {
            get { return _question1; }
            set
            {
                if (_answer != value)
                {
                    _question1 = value;
                    OnPropertyChanged("Question1");
                }
            }
        }
        public int Question2
        {
            get { return _question2; }
            set
            {
                if (_question2 != value)
                {
                    _question2 = value;
                    OnPropertyChanged("Question2");
                }
            }
        }
        public void AddLevels(int addLevel)
        {
            Random rnd = new Random();
            if(addLevel == 0 || addLevel == 1)
            {
               Question1 = rnd.Next(0, 10);
               Question2 = rnd.Next(0, 10);
               Answer = Question1 + Question2;
            }
        }
    }
