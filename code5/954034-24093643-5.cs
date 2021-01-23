	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Windows.Data;
	namespace MultipleDataGrid
	{
		class ViewModel : INotifyPropertyChanged
		{
			private readonly object _lockOne = new object();
			private readonly object _lockTwo = new object();
			private ObservableCollection<StringValue> _sourceOne;
			public ObservableCollection<StringValue> SourceOne
			{ get { return _sourceOne; } }
			private Dictionary<string, List<StringValue>> _sourceTwoList;
			private List<StringValue> _sourceTwo;
			public List<StringValue> SourceTwo
			{
				get { return _sourceTwo; }
				set { _sourceTwo = value; RaisePropertyChanged("SourceTwo"); }
			}
			private StringValue _selectedItem;
			public StringValue SelectedItem
			{
				get { return _selectedItem; }
				set
				{
					_selectedItem = value;
					PopulateDataGridTwo(value.Value);
					RaisePropertyChanged("SelectedItem");
				}
			}
			private void PopulateDataGridTwo(string key)
			{
				if (_sourceTwoList.ContainsKey(key))
				{
					SourceTwo = _sourceTwoList[key];
				}
			}
			public ViewModel()
			{
				_sourceOne = new ObservableCollection<StringValue>
					{
						new StringValue("Key1"),new StringValue("Key2"),new StringValue("Key3")
					};
				_sourceTwoList = new Dictionary<string, List<StringValue>>();
				BindingOperations.EnableCollectionSynchronization(_sourceOne, _lockOne);
				BindingOperations.EnableCollectionSynchronization(_sourceTwoList, _lockTwo);
				_sourceTwoList.Add("Key1", new List<StringValue> { new StringValue("KVOneOne"),new StringValue("KVOneTwo") });
				_sourceTwoList.Add("Key2", new List<StringValue> { new StringValue("KVTwoOne"),new StringValue("KVTwoTwo") });
				_sourceTwoList.Add("Key3", new List<StringValue> { new StringValue("KVThreeOne"),new StringValue("KVThreeTwo") });
				RaisePropertyChanged("SourceOne");
			}
			public event PropertyChangedEventHandler PropertyChanged;
			public void RaisePropertyChanged(string propName)
			{
				var pc = PropertyChanged;
				if (pc != null)
					pc(this, new PropertyChangedEventArgs(propName));
			}
		}
		public class StringValue
		{
			public StringValue(string s)
			{
				_value = s;
			}
			public string Value { get { return _value; } set { _value = value; } }
			string _value;
		}
	}
