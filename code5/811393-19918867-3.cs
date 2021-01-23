        public ICommand OpenSessionCommand { get { return new DelegateCommand<Button>(OpenSession); } }
		public void OpenSession(Button button)
		{
			ContinueReceiving = false;
			dispatcherTimer.Stop();
			Messenger.Default.Send<NavigateMessage>(new NavigateMessage(SessionViewModel.ViewName, this));
		}
