    public class QuestionViewModel : NotifyingObject
    {
        public Question Model { get; private set; }
        public List<AnswerViewModel> PossibleAnswers 
        {
            get { return _possibleAnswers; }
        }
        public DateTime Changed 
        {
            get { return Model.Changed; }
        public AnswerViewModel Answer 
        {
            get { return _answer; }
            set 
            {
                _answer = value;
                // Set properties on your model which are effected
                _model.Answer = _answer.Model;
                _model.Changed = DateTime.Now;
                // Raise property changed events. They are needed
                // to update the UI
                RaisePropertyChanged("Answer");
                RaisePropertyChanged("Date");
            }
        }
        public QuestionViewModel(Question model)
        {
            Model = model;
            _possibleAnswers = Model.Answers.Select(a => new AnswerViewModel(a));
        }
            
    }
    public class AnswerViewModel { ... }
