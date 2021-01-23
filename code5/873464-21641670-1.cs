    public class MainModel : ViewModelBase
	{
		private ObservableCollection<Cell> _Cells;
		public ObservableCollection<Cell> Cells
		{
			get { return _Cells; }
			set { _Cells = value; RaisePropertyChanged(() => this.Cells); }
		}
		public MainModel()
		{
			this.Cells = new ObservableCollection<Cell>(
				Enumerable.Range(1, 100)
				    .Select(i => new Cell { Text = i.ToString() })
			);
		}
	}
