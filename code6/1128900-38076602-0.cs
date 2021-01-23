	public static class PatientDb
	{
		public static IMongoCollection<Patient> Open()
		{
			var client = new MongoClient("mongodb://localhost");
			var db = client.GetDatabase("PatientDb");
			return db.GetCollection<Patient>("Patients");
		} 
	}
