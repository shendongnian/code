    public class MyBinding : Binding
	{
		public String Param {
			get {return this.ConverterParameter.ToString();}
			set {this.ConverterParameter = value;}
		}
		// usage: Text="{local:MyBinding Param=MyText}"
		public MyBinding() : base("TextResource")
		{
			this.Converter = new MyConverter();
		}
		// usage: Text="{local:MyBinding MyText}"
		public MyBinding(string param) : base("TextResource")
		{
			this.Converter = new MyConverter();
			this.Param = param;
		}
	}
