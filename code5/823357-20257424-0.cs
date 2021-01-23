    public class MyBinding : Binding
	{
		public MyBinding(string path) : base(path)
		{
			this.Converter = new MyConverter();
			this.ConverterParameter = "MyText";
		}
	}
