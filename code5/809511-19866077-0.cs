	public class PersonVm : DependencyObject
	{
		public PersonVm(Model.Person model)
		{
			_model = model;
			Name = model.Name;
			Age = model.Age;
			foreach (var professionModel in model.Professions)
			{
				Professions.Add(new ProfessionVm(professionModel));
			}
		}
		Model.Person _model;
		public int Id { get { return _model.Id; } }
		//Name Dependency Property
		public string Name
		{
			get { return (string)GetValue(NameProperty); }
			set { SetValue(NameProperty, value); }
		}
		public static readonly DependencyProperty NameProperty =
			DependencyProperty.Register("Name", typeof(string), typeof(PersonVm), new UIPropertyMetadata(null));
		//Age Dependency Property
		public int Age
		{
			get { return (int)GetValue(AgeProperty); }
			set { SetValue(AgeProperty, value); }
		}
		public static readonly DependencyProperty AgeProperty =
			DependencyProperty.Register("Age", typeof(int), typeof(PersonVm), new UIPropertyMetadata(null));
		//Professions Observable Collection
		private ObservableCollection<ProfessionVm> _professions = new ObservableCollection<ProfessionVm>();
		public ObservableCollection<ProfessionVm> Professions { get { return _professions; } }
	}
