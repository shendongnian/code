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
				if (columnName == Name)
				{
					if (string.IsNullOrEmpty(Name))
					{
						result = "Please enter a First name";
					}
				}
				return result;
			}
		}
    }
