   	public interface IClientDTO {
		string FirstName { get; }
		string LastName { get; }
	}
	public interface IAdminDTO {
		string FirstName { get; }
		string LastName { get; }
		string SSN { get; }
	}
	class ClientDTO : IClientDTO {
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
	class AdminDTO : IAdminDTO {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string SSN { get; set; }
	}
	class Model {
		class DTO {
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string SSN { get; set; }
		}
		private DTO dto = new DTO() { FirstName = "John", LastName = "Doe", SSN = "111001111" };
		public IClientDTO ClientDTO { get { return new ClientDTO() { FirstName = dto.FirstName, LastName = dto.LastName }; } }
		public IAdminDTO AdminDTO { get { return new AdminDTO() { SSN = dto.SSN, FirstName = dto.FirstName, LastName = dto.LastName }; } }
	}
	class Program {
		static void Main(string[] args) {
			Model model = new Model();
			string sClientDTO = JsonConvert.SerializeObject(model.ClientDTO);
			string sAdminDTO = JsonConvert.SerializeObject(model.AdminDTO);
			Debug.WriteLine(sClientDTO);
			Debug.WriteLine(sAdminDTO);
		}
	}
