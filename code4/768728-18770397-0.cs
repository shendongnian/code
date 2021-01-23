	void Main()
	{
		var myList = new List<MyThing>{
			new MyThing{Name="Lee", Age=31},
			new MyThing{Name="Dave", Age=37},
			new MyThing{Name="Erik", Age=44},
			new MyThing{Name="Bart", Age=24},
			new MyThing{Name="James", Age=32},
		};
		
		var subscription = Observable.Merge(myList.Select(t=>t.OnAnyPropertyChanges()))
					.Subscribe(x=>Console.WriteLine("{0} is {1}", x.Name, x.Age));
					
		myList[0].Age = 33;
		myList[3].Name = "Bob";
		
		subscription.Dispose();
	}
	
	// Define other methods and classes here
	public class MyThing : INotifyPropertyChanged
	{
	private string _name;
	private int _age;
	
	public string Name
	{
		get { return _name; }
		set
		{
			_name = value;
			OnPropertyChanged("Name");
		}
	}
	
	public int Age
	{
		get { return _age; }
		set
		{
			_age = value;
			OnPropertyChanged("Age");
		}
	}
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void OnPropertyChanged(string propertyName)
	{
		var handler = PropertyChanged;
		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	}
	}
		
	public static class NotificationExtensions
	{
		/// <summary>
		/// Returns an observable sequence of the source any time the <c>PropertyChanged</c> event is raised.
		/// </summary>
		/// <typeparam name="T">The type of the source object. Type must implement <seealso cref="INotifyPropertyChanged"/>.</typeparam>
		/// <param name="source">The object to observe property changes on.</param>
		/// <returns>Returns an observable sequence of the value of the source when ever the <c>PropertyChanged</c> event is raised.</returns>
		public static IObservable<T> OnAnyPropertyChanges<T>(this T source)
			where T : INotifyPropertyChanged
		{
				return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
									handler => handler.Invoke,
									h => source.PropertyChanged += h,
									h => source.PropertyChanged -= h)
								.Select(_=>source);
		}
	}
