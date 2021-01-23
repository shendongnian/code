    public class MainViewModel : ViewModelBase
	{
		private PopUpViewModel _PopUp;
		public PopUpViewModel PopUp
		{
			get { return _PopUp; }
			set { _PopUp = value; RaisePropertyChanged(() => this.PopUp); }
		}		
	}
	public class PopUpViewModel : ViewModelBase
	{
		private string _Message;
		public string Message
		{
			get { return _Message; }
			set { _Message = value; RaisePropertyChanged(() => this.Message); }
		}
	}
