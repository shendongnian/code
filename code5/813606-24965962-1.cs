    public MyReturnType GetMyTypeAsXml() {
		Configuration = new HttpConfiguration();
		Configuration.Formatters.Clear();
		Configuration.Formatters.Add(new XmlMediaTypeFormatter());
		return new MyReturnType();
	}
	public MyReturnType GetMyTypeAsJson() {
		Configuration = new HttpConfiguration();
		Configuration.Formatters.Clear();
		Configuration.Formatters.Add(new JsonMediaTypeFormatter());
		return new MyReturnType();
	}
