    public MyBinding(string param)
			: base("TextResource")
		{
			this.Converter = new MyConverter();
			this.ConverterParameter = param;
		}
