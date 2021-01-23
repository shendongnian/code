	private Action _myRootDisconnect = null;
	private object _myRootGate = new object();
	private ItemContainerRoot _myRoot;
	public ItemContainerRoot Root
	{
		get { return _myRoot; }
		set
		{
			lock (_myRootGate)
			{
				Action<int> setProgressBar = val =>
				{
					this.Invoke((Action)(() =>
					{
						this.progressBarControl1.Position = val;
					}));
				};
				
				if (_myRootDisconnect != null)
				{
					_myRootDisconnect();
					_myRootDisconnect = null;
				}
				
				_myRoot = value;
				_myRoot.SetProgressBar += setProgressBar;
				
				_myRootDisconnect = () =>
				{
					_myRoot.SetProgressBar -= setProgressBar;
				};
			}
		}
	}
