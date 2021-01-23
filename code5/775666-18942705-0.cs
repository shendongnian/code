    public IObservable<Employee> GetEmployees()
    {
        return Observable.Create<Employee>(o =>
			Observable.Using(() => new SqlConnection(ConfigurationManager
				.ConnectionStrings["DBConnString"].ConnectionString),
				connection =>
					Observable.Using(() =>
					{
						connection.Open();
						return new SqlCommand(
							@"SELECT * FROM EMPLOYEES", connection);
					},
						command =>
							Observable.Using(() => command.ExecuteReader(),
								reader =>
									Observable.Generate(
										0,
										x => reader.Read(),
										x => x,
										x => new Employee()
									{
										Id = ReadField<int>(reader, "Id"),
										Name = ReadField<string>(reader, "Name")
									}, Scheduler.Default)))).Subscribe(o));
    }
