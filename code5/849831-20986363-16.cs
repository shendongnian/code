        OppositeMeanings,
        LinkWords
    }
    public class Instruction
    {
        public string Name { get; set; }
        public ObservableCollection<Question> Questions { get; set; }
    }
    public class Question : INotifyPropertyChanged
    {
        private Choice selectedChoice;
        private string instruction;
        public Question()
        {
            Choices = new ObservableCollection<Choice>();
        }
        public string Name { set; get; }
        public bool IsInstruction { get { return !string.IsNullOrEmpty(Instruction); } }
        public string Instruction
        {
            get { return instruction; }
            set
            {
                if (value != instruction)
                {
                    instruction = value;
                    OnPropertyChanged();
                    OnPropertyChanged("IsInstruction");
                }
            }
        }
        public string Clue { set; get; }
        public ObservableCollection<Choice> Choices { set; get; }
        public QuestionType Qtype { set; get; }
        public Choice SelectedChoice
        {
            get { return selectedChoice; }
            set
            {
                if (value != selectedChoice)
                {
                    selectedChoice = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Marks { set; get; }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Choice
    {
        public string Name { get; set; }
        public bool isChecked { get; set; }
    }
    public class NestedItemsViewModel
    {
        public NestedItemsViewModel()
        {
            Questions = new ObservableCollection<Question>();
            for (var h = 0; h <= 1; h++)
            {
                Questions.Add(new Question() {Instruction = string.Format("Instruction {0}", h)});
                for (int i = 1; i < 5; i++)
                {
                    Question qn = new Question() { Name = "Qn" + ((4 * h) + i)};
                    for (int j = 0; j < 4; j++)
                    {
                        qn.Choices.Add(new Choice() { Name = "Choice" + j });
                    }
                    Questions.Add(qn);
                }
            }
        }
        public ObservableCollection<Question> Questions { get; set; }
        internal void SelectChoice(int questionIndex, int choiceIndex)
        {
            var question = this.Questions[questionIndex];
            question.SelectedChoice = question.Choices[choiceIndex];
        }
    }
