    public class TestListProperty
	{
		public ListProperty ListData { get; private set; }
		//---------------------------
		public class ListProperty : INotifyCollectionChanged
		{
			private ObservableCollection<string> m_data;
			internal ListProperty()
			{
				m_data = new ObservableCollection<string>();
				m_data.CollectionChanged += (s, e) =>
				{
					if (CollectionChanged != null)
						CollectionChanged(s, e);
				};
			}
			public string this[int index]
			{
				get
				{
					if (m_data.Count > index)
					{
						return m_data[index];
					}
					else
					{
						return "Element not set for " + index.ToString();
					}
				}
				set
				{
					if (m_data.Count > index)
					{
						m_data[index] = value;
					}
					else
					{
						m_data.Insert(index, value);
					}
					Console.WriteLine(value);
				}
			}
			public event NotifyCollectionChangedEventHandler CollectionChanged;
		}
		//---------------------------
		public TestListProperty()
		{
			ListData = new ListProperty();
		}
	}
