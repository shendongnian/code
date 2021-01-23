    public class User : IDataErrorInfo, INotifyPropertyChanged
	{
		private int id;
		public int Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
				OnPropertyChanged("Id");
			}
		}
		private string name;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}
		private int salary;
		public int Salary {
			get
			{
				return salary;
			}
			set
			{
				salary = value;
				OnPropertyChanged("Salary");
			}
		}
		public string Error
		{
			get
			{
				return null;
			}
		}
		public string this[string columnName]
		{
			get
			{
				string result = null;
				if (columnName == "Name")
				{
					if (string.IsNullOrEmpty(Name))
					{
						result = "Please enter a First name";
					}
				}
				if (columnName == "Salary")
				{
					if (Salary <= 0)
					{
						result = "Please enter a valid salary";
					}
				}
				if (columnName == "Id")
				{
					if (Id < 0)
					{
						result = "Please enter a valid id";
					}
				}
				return result;
			}
		}
		public User()
		{
			
		}
		public User(int id, string name, int salary)
		{
			Id = id;
			Name = name;
			Salary = salary;
		}
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
