       	private ICommand _animateObjectCommand;
		public ICommand AnimateObjectCommand
		{
			get
			{
				if (_animateObjectCommand == null)
				{
					_animateObjectCommand = new RelayCommand<AnimationObject>( ao => { ao.Animate(); });
				}
				return _animateObjectCommand;
			}
		}
