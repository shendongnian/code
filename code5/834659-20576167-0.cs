   	public class MyViewModel : ViewModelBase
	{
		private double _FontSize = 0.0;
		public double FontSize
		{
			get { return this._FontSize; }
			set { this._FontSize = value; RaisePropertyChanged(() => this.FontSize); }
		}
	}
