    namespace SO19941925
    {
		internal class Program
		{
			private static void Main(string[] args)
			{
				IDocumentStore store = new DocumentStore
									   {
										   Url = "http://localhost:8080",
										   DefaultDatabase = "SO19941925"
									   }.Initialize();
				using (IDocumentSession session = store.OpenSession())
				{
					for (int i = 0; i < 10; i++)
					{
						session.Store(new User {Name = "User" + i});
					}
					session.SaveChanges();
				}
				using (IDocumentSession session = store.OpenSession())
				{
					List<User> users = session.Query<User>().Customize(x => x.WaitForNonStaleResultsAsOfNow()).ToList();
					Console.WriteLine("{0} SO19941925.Users", users.Count);
				}
				Operation s = store.DatabaseCommands.UpdateByIndex("Raven/DocumentsByEntityName",
					new IndexQuery {Query = "Tag:Users"},
					new ScriptedPatchRequest
					{
						Script = @"this['@metadata']['Raven-Clr-Type'] = 'SO19941925.Models.User, SO19941925';"
					}, true
					);
				s.WaitForCompletion();
				using (IDocumentSession session = store.OpenSession())
				{
					List<Models.User> users =
						session.Query<Models.User>().Customize(x => x.WaitForNonStaleResultsAsOfNow()).ToList();
					Console.WriteLine("{0} SO19941925.Models.Users", users.Count);
				}
				Console.ReadLine();
			}
		}
		internal class User
		{
			public string Name { get; set; }
		}
	}
	namespace SO19941925.Models
	{
		internal class User
		{
			public string Name { get; set; }
		}
	}
