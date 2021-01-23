EF.vshost.exe|0|SqlDataReader: 67
EF.vshost.exe|1|SqlDataReader: 0
EF.vshost.exe|2|SqlDataReader: 0
AppDomain0|0|SqlDataReader: 313
AppDomain0|1|SqlDataReader: 2
AppDomain0|2|SqlDataReader: 0
AppDomain1|0|SqlDataReader: 290
AppDomain1|1|SqlDataReader: 3
AppDomain1|2|SqlDataReader: 0
AppDomain2|0|SqlDataReader: 316
AppDomain2|1|SqlDataReader: 2
AppDomain2|2|SqlDataReader: 0
	public class SamplePlugin : MarshalByRefObject, IPlugin
	{
		public void Do(int i)
		{
			var watch = Stopwatch.StartNew();
			using (var connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=EF.Plugin.MyContext;Integrated Security=true"))
			{
				var command = new SqlCommand("SELECT * from Posts;", connection);
				connection.Open();
				var reader = command.ExecuteReader();
				reader.Close();
			}
			watch.Stop();
			Console.WriteLine(AppDomain.CurrentDomain.FriendlyName + "|" + i + "|SqlDataReader: " + watch.ElapsedMilliseconds);
		}
	}
