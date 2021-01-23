	using System;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Windows;
	using System.Windows.Data;
	namespace WpfApplication4
	{
		public partial class MainWindow : Window, INotifyPropertyChanged
		{
			public MainWindow()
			{
				InitializeComponent();
				DataContext = this;
				Items = new ObservableCollection<TopGridItem>();
				Items.Add(new TopGridItem { Name = "One" });
				Items.Add(new TopGridItem { Name = "Two" });
				Items.Add(new TopGridItem { Name = "Three" });
			}
			public String Name1 { get; set; }
			public String Index { get; set; }
			public ObservableCollection<TopGridItem> Items { get; private set; }
			public TopGridItem SelectedItem
			{
				get { return _selectedItem; }
				set
				{
					_selectedItem = value;
					OnPropertyChanged("SelectedItem");
					if (_selectedItem != null)
					{
						_selectedItem.ResetView();
					}
				}
			}
			TopGridItem _selectedItem;
			public event PropertyChangedEventHandler PropertyChanged;
			protected virtual void OnPropertyChanged(string propertyName)
			{
				PropertyChangedEventHandler handler = PropertyChanged;
				if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		public class TopGridItem : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged;
			protected virtual void OnPropertyChanged(string propertyName)
			{
				PropertyChangedEventHandler handler = PropertyChanged;
				if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
			}
			public String Name { get; set; }
			public ICollectionView MyCollectionView
			{
				get
				{
					return _myCollectionView;
				}
				set
				{
					_myCollectionView = value;
					OnPropertyChanged("MyCollectionView");
				}
			}
			ICollectionView _myCollectionView;
			public void ResetView()
			{
				MyCollectionView = null;
				ICollectionView _customerView = CollectionViewSource.GetDefaultView(_collection);
				_customerView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
				MyCollectionView = _customerView;
			}
			ObservableCollection<BottomGridItem> _collection;
			public TopGridItem()
			{
				_collection = new ObservableCollection<BottomGridItem>();
				_collection.Add(new BottomGridItem { Name = "bbbbbb" });
				_collection.Add(new BottomGridItem { Name = "aaaaa" });
				_collection.Add(new BottomGridItem { Name = "aaaaa" });
				_collection.Add(new BottomGridItem { Name = "ccccc" });
				_collection.Add(new BottomGridItem { Name = "dddddd" });
				ResetView();
			}
		}
		public class BottomGridItem
		{
			public String Name { get; set; }
			public String Index { get; set; }
		}
	}
