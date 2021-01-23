	class TabSelectedBehavior : Behavior<TabItem>
	{
		public static readonly DependencyProperty SelectedCommandProperty = DependencyProperty.Register("SelectedCommand", typeof(ICommand), typeof(TabSelectedBehavior));
		public ICommand SelectedCommand
		{
			get { return (ICommand)GetValue(SelectedCommandProperty); }
			set { SetValue(SelectedCommandProperty, value); }
		}
		private EventHandler _selectedHandler;
		protected override void OnAttached()
		{
			DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(TabItem.IsSelectedProperty, typeof(TabItem));
			if (dpd != null)
			{
				_selectedHandler = new EventHandler(AssociatedObject_SelectedChanged);
				dpd.AddValueChanged(AssociatedObject, _selectedHandler);
			}
			base.OnAttached();
		}
		protected override void OnDetaching()
		{
			DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(TabItem.IsSelectedProperty, typeof(TabItem));
			if (dpd != null && _selectedHandler != null)
			{
				dpd.RemoveValueChanged(AssociatedObject, _selectedHandler);
			}
			base.OnDetaching();
		}
		void AssociatedObject_SelectedChanged(object sender, EventArgs e)
		{
			if (AssociatedObject.IsSelected)
			{
				if (SelectedCommand != null)
				{
					SelectedCommand.Execute(null);
				}
			}
		}
	}
