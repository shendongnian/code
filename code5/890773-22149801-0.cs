	[DataContract]
	public class AuthTokenContract
	{
		[DataMember(Name = "result")]
		public Result result { get; set; }
		[DataMember(Name = "warnings")]
		public string[] Warnings { get; set; }
	}
	[DataContract]
	public class Result
	{
		[DataMember(Name = "token")]
		public string Token { get; set; }
	}
