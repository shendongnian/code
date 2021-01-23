	public class JQueryVersion
	{
		public string File_Name { get; set; }
		
		public string Version
		{
			get
			{
				return Regex.Match(this.File_Name, @"jquery-([0-9]{1,2}\.[0-9]{1,2}\.[0-9]{1,2})\.").Groups[1].Value;
			}
		}		
		
		public int[] Version_Numeric
		{
			get
			{
				return this.Version.Split('.').Select(v => int.Parse(v)).ToArray();
			}
		}
		
		public JQueryVersion (string File_Name)
		{
			this.File_Name = File_Name;
		}
	}
