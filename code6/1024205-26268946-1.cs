    public IEnumerable<string> GetSchoolProperties()
	{
		return typeof(School).GetProperties().Select(property => property.Name);
	}
	
	public class School
	{
		public string SchoolId { get; set; }
		public string Name { get; set; }
	}
