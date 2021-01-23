         class SomeOtherClass<T> : ObservableCollection<T>
		{
			public void InvokeAllOnChangedObservers()
			{
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)); // or OnCollectionChanged(null);
			}
		}
		static void Main(string[] args)
		{
			SomeOtherClass<string> a = new SomeOtherClass<string>();
			a.CollectionChanged += (sender, evnt) =>
			{
				Console.WriteLine("Handler");
			};
			a.InvokeAllOnChangedObservers(); // prints handler
		}
