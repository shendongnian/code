    	public Tuple<string, string>[] GetGeneratorContent(params string[] xmlFileNames)
	{
		List<Tuple<string, string>> result = new List<Tuple<string, string>>();
		foreach(string xmlFileName in xmlFileNames)
		{
			TheBallCoreAbstractionType abs = LoadXml<TheBallCoreAbstractionType>(xmlFileName);
			CurrentAbstraction = abs;
			this.GenerationEnvironment.Clear();
			string content = TransformText();
			string outputFile = Path.GetFileNameWithoutExtension(xmlFileName) + ".designer.cs";
			result.Add(Tuple.Create(outputFile, content));
		}
		return result.ToArray();
	}
