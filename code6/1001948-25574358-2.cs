    public static void BindText(TextBox box, object dataSource, string dataMember)
		{
			var bind = new Binding("Text", dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
			bind.Format += (s, e) => { e.Value = e.Value == null ? null : ((string)e.Value).Length == 0 ? null : e.Value; };
			bind.Parse += (s, e) => { e.Value = e.Value == null ? null : ((string)e.Value).Length == 0 ? null : e.Value; };
			box.DataBindings.Add(bind);
		}
