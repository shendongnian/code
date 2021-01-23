	// helper class
	public class Dummy
	{
		public String Field { get; set; }
	}
	//
	var value = "V\u00E4xj\u00F6";
	var sb = new StringBuilder();
	sb.Append("{");
	sb.Append(String.Format(@"""Field"" : ""{0}""", value));
	sb.Append("}");
	var dummy = Json.Decode(sb.ToString());
	Console.WriteLine(dummy.Field);
	// it works also without helper class
	var obj = Json.Decode(sb.ToString());
	Console.WriteLine(obj.Field);
