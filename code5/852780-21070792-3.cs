	public class MyViewModel : ViewModelBase
	{
		public ICommand MouseDownCommand { get; set; }
		public ICommand MouseUpCommand { get; set; }
		public ICommand MouseMoveCommand { get; set; }
		public ICommand KeyDownCommand { get; set; }
		// I'm using a dependency injection framework which is why I'm
		// doing this here, otherwise you could do it in the constructor
		[InjectionMethod]
		public void Init()
		{
			this.MouseDownCommand = new RelayCommand<MouseButtonEventArgs>(args => OnMouseDown(args));
			this.MouseUpCommand = new RelayCommand<MouseButtonEventArgs>(args => OnMouseUp(args));
			this.MouseMoveCommand = new RelayCommand<MouseEventArgs>(args => OnMouseMove(args));
			this.KeyDownCommand = new RelayCommand<KeyEventArgs>(args => OnKeyDown(args));			
		}
		private void OnMouseDown(MouseButtonEventArgs args)
		{
			// handle mouse press here
		}
		// OnMouseUp, OnMouseMove and OnKeyDown handlers go here
	}
