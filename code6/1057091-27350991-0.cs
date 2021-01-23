	class ParentViewModel : BaseViewModel
	{
		private double _parentAmount;
		public double parentAmount
		{
			get { return _parentAmount; }
			set
			{
				if (value != _parentAmount)
				{
					_parentAmount = value;
					NotifyPropertyChanged("parentAmount");
				}
			}
		}
		private ObservableCollection<ChildViewModel> _children;
		public ObservableCollection<ChildViewModel> children
		{
			get { return _children; }
			set
			{
				if (value != _children)
				{
					_children = value;
					foreach (var child in _children)
						child.PropertyChanged += ChildOnPropertyChanged;
					NotifyPropertyChanged("children");
				}
			}
		}
		private void ChildOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
		{
			parentAmount = children.Sum(p => p.ChildAmount);
		}
	}
	class ChildViewModel : BaseViewModel
	{
		private double _ChildAmount;
		public double ChildAmount
		{
			get { return _ChildAmount; }
			set
			{
				if (value != _ChildAmount)
				{
					_ChildAmount = value;
					NotifyPropertyChanged("ChildAmount");
				}
			}
		}
	}
	public class BaseViewModel : INotifyPropertyChanged
	{
		protected void NotifyPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
