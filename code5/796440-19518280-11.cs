    public class User : IDataErrorInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Salary { get; set; }
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
    }
