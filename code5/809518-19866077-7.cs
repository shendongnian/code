		//Name Dependency Property
		public string Name
		{
			get { return (string)GetValue(NameProperty); }
			set { SetValue(NameProperty, value); }
		}
		public static readonly DependencyProperty NameProperty =
			DependencyProperty.Register("Name", typeof(string), typeof(PersonVm),
			new UIPropertyMetadata(null, (d, e) =>
			{
				var vm = (PersonVm)d;
				var val = (string)e.NewValue;
				vm._model.Name = val;
			}));
