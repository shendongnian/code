    public static void BindText(TextBox box, object dataSource, string dataMember)
		{
			var bind = new Binding("Text", dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
			box.DataBindings.Add(bind);
		}
