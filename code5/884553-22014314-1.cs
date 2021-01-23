    public class PersonViewModel : INotifyPropertyChanged
	{
		private Person person;
		public PersonViewModel(Person person)
		{
			this.person = person;
		}
		public DateTime Birthday
		{
			get { return person.Birthday; }
			set 
			{ 
				person.Birthday = value;
				OnPropertyChanged("Birthday");
				OnPropertyChanged("BirthdayForList");
				OnPropertyChanged("BirthdayForDetails");
			}
		}
		public string Name
		{
			get { return person.Name; }
			set 
			{ 
				person.Name = value; 
				OnPropertyChanged("Name");
				OnPropertyChanged("BirthdayForDetails");
			}
		}
		public string BirthdayForList
		{
			get
			{
				return "Birthday: " + Birthday.ToString("ddd", CultureInfo.CurrentCulture);
			}
		}
		public string BirthdayForDetails
		{
			get
			{
				return Name + "'s birthday is " + Birthday.ToString("ddd", CultureInfo.CurrentCulture);
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
