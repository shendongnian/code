	public class MainViewModel : DependencyObject
	{
		public MainViewModel(IEnumerable<Model.Person> models)
		{
			foreach (var personModel in models)
			{
				People.Add(new PersonVm(personModel));
			}
		}
		//People Observable Collection
		private ObservableCollection<PersonVm> _people = new ObservableCollection<PersonVm>();
		public ObservableCollection<PersonVm> People { get { return _people; } }
		//SelectedPerson Dependency Property
		public PersonVm SelectedPerson
		{
			get { return (PersonVm)GetValue(SelectedPersonProperty); }
			set { SetValue(SelectedPersonProperty, value); }
		}
		public static readonly DependencyProperty SelectedPersonProperty =
			DependencyProperty.Register("SelectedPerson", typeof(PersonVm), typeof(MainViewModel), new UIPropertyMetadata(null));
	}
