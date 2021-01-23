	namespace NFSe.Classes.Models.Classes.NFSeWeb
	{
		public class Service
		{
			public string IdService { get; set; }
			public string Name { get; set; }
			public string getKey()
			{
				return IdService + Name;
			}
		}
	}
