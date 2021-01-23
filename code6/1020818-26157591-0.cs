		public int SelectedDocumentIndex
		{
			get { return (int)GetValue(SelectedDocumentIndexProperty); }
			set { SetValue(SelectedDocumentIndexProperty, value); }
		}
		public static readonly DependencyProperty SelectedDocumentIndexProperty =
			DependencyProperty.Register("SelectedDocumentIndex", typeof(int), typeof(MyViewModel), new PropertyMetadata(0,
				(d, e) =>
				{
					//Callback after value is changed
					var vm = (MyViewModel)d;
					var val = (int)e.NewValue;
				}, (d, v) =>
				{
					//Coerce before value is changed
					var vm = (MyViewModel)d;
					var val = (int)v;
					if (vm.tabsCollection.Count() > 1 && vm.CanSave() == true)
					{
						if (vm.dm.ShowMessage1(ServiceContainer.GetService<DevExpress.Mvvm.IDialogService>("confirmYesNo")))
						{
							//no coerce is needed
							return v;
						}
						else
						{
							//should coerce to the previous value
							return VM.SelectedDocumentIndex;
						}
					}
					else
					{
						//no coerce is needed
						return v;
					}
				}));
