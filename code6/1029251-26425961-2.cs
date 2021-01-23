			// data is a rough equivalent of DataTable being imported
			var data = new List<Dictionary<string, string>>
			{
				new Dictionary<string, string> { { "column1", "asd asfs af" }, { "column2", "45dfdsf d6" }, { "column3", "7hgj  gh89" } },
				new Dictionary<string, string> { { "column1", "aaasdfda" }, { "column2", "45sdfdsf 6" }, { "column3", "78gh jghj9" } },
				new Dictionary<string, string> { { "column1", "s dfds fds f" }, { "column2", "4dsf dsf 56" }, { "column3", "78gh jgh j9" } },
			};
			// a list of columns to map to
			var importToColumns = new List<string>
			{
				"123",
				"aaa",
				"qwe",
				"456",
				"bbb"
			};
			importMappings = new Dictionary<string, int>();
			foreach(var column in data[0])
			{
				importMappings.Add(column.Key, -1);
			}
			foreach(var r in importMappings)
			{
				var dgtc = new DataGridTextColumn();
				dgtc.Binding = new Binding(string.Format("[{0}]", r.Key));
				var sp = new StackPanel();
				dgtc.Header = sp;
				sp.Children.Add(new Label { Content = r.Key });
				var combo = new ComboBox();
				sp.Children.Add(combo);
				combo.ItemsSource = importToColumns;
				var selectedBinding = new Binding(string.Format("[{0}]", r.Key));
				selectedBinding.Source = importMappings;
				combo.SetBinding(Selector.SelectedIndexProperty, selectedBinding);
				dgtc.MinWidth = 100;
				dgtc.CanUserSort = false;
				dg.Columns.Add(dgtc);
			}
			dg.ItemsSource = data;
		}
		private Dictionary<string, int> importMappings;
