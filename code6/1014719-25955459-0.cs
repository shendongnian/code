    	public void Execute(CoroutineExecutionContext context)
		{
			Task.Factory.StartNew(() =>
			{
				object screen = null;
				var shell = IoC.Get<IShell>();
				if (_viewModel != null)
				{
					screen = _viewModel;
				}
				else
				{
					screen = !String.IsNullOrEmpty(_name)
						? IoC.Get<object>(_name)
						: IoC.GetInstance(_screenType, null);
				}
				shell.ActivateItem(screen);
				Completed(this, new ResultCompletionEventArgs());
			});
		}
