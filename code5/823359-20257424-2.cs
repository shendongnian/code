    public class MyBinding : Binding
	{
		public String Param {
			get {return this.ConverterParameter.ToString();}
			set {this.ConverterParameter = value;}
		}
		// useage: Text="{local:MyBinding MyText1}"
		public MyBinding() : base("TextResource")
		{
			this.Converter = new MyConverter();
		}
		// useage: Text="{local:MyBinding Param=MyText2}"
		public MyBinding(string param) : base("TextResource")
		{
			this.Converter = new MyConverter();
			this.Param = param;
		}
	}
