        private PageViewModel _CurrentPage;
		public PageViewModel CurrentPage
		{
			get { return _CurrentPage; }
			set { _CurrentPage = value; RaisePropertyChanged(() => this.CurrentPage); }
		}
