	public class MyViewModel : ObservableObject
	{
		public ICommand AddQuestionCommand {get; private set;}
		ObservableCollection<string> _questions = new ObservableCollection<string>();
		public ObservableCollection<string> Questions
		{
			get { return _questions; }
			set
			{
				_questions = value;
				OnPropertyChanged(() => Questions);
			}
		}
		public MyViewModel()
		{
			this.AddQuestionCommand = new RelayCommand(new Action<object>((o) => OnAddQuestion()));
		}
		private void OnAddQuestion()
		{
			this.Questions.Add("new item");
		}
		
	}
