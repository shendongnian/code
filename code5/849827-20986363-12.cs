        public enum QuestionType
        {
            OppositeMeanings,
            LinkWords
            //todo
        }
        public class Question : INotifyPropertyChanged
        {
            private Choice selectedChoice;
            public Question()
            {
                Choices = new ObservableCollection<Choice>();
            }
            public string Name { set; get; }
            public string Instruction { set; get; }
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
                for (int i = 0; i < 10; i++)
                {
                    Question qn = new Question();
                    qn.Name = "Qn" + i;
                    for (int j = 0; j < 4; j++)
                    {
                        Choice ch = new Choice();
                        ch.Name = "Choice" + j;
                        qn.Choices.Add(ch);
                    }
                    Questions.Add(qn);
                }
            }
            public ObservableCollection<Question> Questions { get; set; }
            internal void SelectChoice(int questionIndex, int choiceIndex)
            {
                var question = this.Questions[questionIndex];
                question.SelectedChoice = question.Choices[choiceIndex];
            }
        }
