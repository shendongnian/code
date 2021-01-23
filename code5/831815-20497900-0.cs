	public class WidgetRepository
	{
		private readonly string _primaryConnectionString;
		private readonly string _secondaryConnectionString;
		public WidgetRepository(string primaryConnectionString, string secondaryConnectionString)
		{
			_primaryConnectionString = primaryConnectionString;
			_secondaryConnectionString = secondaryConnectionString;
		}
		
		public void AddWidget(Widget widget)
		{
			ExecuteAction(AddWidgetAction(widget));
		}
		
		public void UpdateWidget(Widget widget)
		{
			ExecuteAction(UpdateWidgetAction(widget));
		}
		
		private Action<string> AddWidgetAction(Widget widget)
		{
			return Action<string>(connectionString => {
				using (var connection = new SqlConnection(connectionString))
				{
					using (var command = connection.CreateCommand())
					{
						command.CommandText = "INSERT INTO Widgets(name, price) VALUES(@name, @price)";
						command.Parameters.AddWithValue("@name", widget.Name);
						command.Parameters.AddWithValue("@price", widget.Price);
						command.ExecuteNonQuery();
					}			
				}
			});
		}
		
		private Action<string> UpdateWidgetAction(Widget widget)
		{
			// Logic here to update a widget
		}
		
		private void ExecuteAction(Action<string> action)
		{
			try
			{
				action(_secondaryConnectionString);
			}
			catch (SqlException)
			{
				action(_secondaryConnectionString);
			}
		}	
	}
