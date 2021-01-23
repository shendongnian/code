	/// <summary>
	/// Defines the base class for application wide shortcuts.
	/// </summary>
	public abstract class ApplicationShortcut
	{
		/// <summary>
		/// The <see cref="ICommand"/> to be executed.
		/// </summary>
		public abstract ICommand Command { get; }
		/// <summary>
		/// The <see cref="InputGesture"/> defining how the <see cref="ApplicationShortcut.Command"/> is invoked.
		/// </summary>
		public abstract InputGesture Shortcut { get; }
		/// <summary>
		/// Registers the <see cref="ApplicationShortcut"/> with the application.
		/// </summary>
		public abstract void RegisterShortcut();
	}
	/// <summary>
	/// Base class that defines an <see cref="ICommand"/> that is routed through the element tree and contains a text property.
	/// </summary>
	/// <typeparam name="T">The type that is registered with the command.</typeparam>
	public abstract class RoutedUIShortcut<T> : ApplicationShortcut
	{
		/// <summary>
		/// The type registered with the command.
		/// </summary>
		protected readonly Type OwnerType = typeof (T);
		/// <summary>
		/// The <see cref="RoutedUICommand"/> to be executed.
		/// </summary>
		protected abstract RoutedUICommand RoutedCommand { get; }
		/// <summary>
		/// The <see cref="ICommand"/> to be executed.
		/// </summary>
		public override sealed ICommand Command
		{
			get { return RoutedCommand; }
		}
		/// <summary>
		/// Registers the <see cref="ApplicationShortcut"/> with the application.
		/// </summary>
		public override void RegisterShortcut()
		{
			CommandManager.RegisterClassCommandBinding(OwnerType, new CommandBinding(Command, OnExecuted, OnCanExecute));
		}
		/// <summary>
		/// Represents the method that will handle the <see cref="CommandBinding.CanExecute"/> routed event.
		/// </summary>
		/// <param name="sender">The command target that is invoking the handler.</param>
		/// <param name="e">The event data.</param>
		protected virtual void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}
		/// <summary>
		/// Represents the method that will handle the <see cref="CommandBinding.Executed"/> and <see cref="CommandBinding.PreviewExecuted"/> routed events, as well as related attached events.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">The event data.</param>
		protected abstract void OnExecuted(object sender, ExecutedRoutedEventArgs e);
	}
