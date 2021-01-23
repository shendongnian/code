	public class ViewModel : DependencyObject
	{
		//Text Dependency Property
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(ViewModel),
			new UIPropertyMetadata(null, (d, e) =>
			{
				((ViewModel)d).IsSelected = !string.IsNullOrWhiteSpace((string)e.NewValue);
			}));
		//IsSelected Dependency Property
		public bool IsSelected
		{
			get { return (bool)GetValue(IsSelectedProperty); }
			set { SetValue(IsSelectedProperty, value); }
		}
		public static readonly DependencyProperty IsSelectedProperty =
			DependencyProperty.Register("IsSelected", typeof(bool), typeof(ViewModel),
			new UIPropertyMetadata(false, (d, e) =>
			{
				var vm = (ViewModel)d;
				if ((bool)e.NewValue)
					vm.SelectionList.Add(vm);
				else
					vm.SelectionList.Remove(vm);
			}));
	}
