	public class Person
	{
		public string Id { get; set; }
		
		public string Firstname { get; set; }
		
		public string Lastname { get; set; }
		[ElasticProperty(Store=false, Index=FieldIndexOption.not_analyzed)]
		public string Email { get; set; }
		
		[ElasticProperty(Store = false, Index = FieldIndexOption.not_analyzed)]
		public string Posts { get; set; }
		
		[ElasticProperty(Store = false, Index = FieldIndexOption.not_analyzed)]
		public string YearsOfExperience { get; set; }
	}
