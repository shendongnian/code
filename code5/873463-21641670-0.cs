    public class Cell : ViewModelBase
	{
		private string _Text;
		public string Text
		{
			get { return _Text; }
			set { _Text = value; RaisePropertyChanged(() => this.Text); }
		}
	}
