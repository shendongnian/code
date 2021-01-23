    [Test]
    public void MsBuildPropertyContainsRefeerenceAssemblyFolder() {
    	var project = new Project(@"D:\\Projects\\Chpokk\\src\\Chpokk.Tests\\Chpokk.Tests.csproj");
    	var property = project.AllEvaluatedProperties.First(projectProperty => projectProperty.Name == "FrameworkPathOverride");
    	Console.WriteLine(property.EvaluatedValue);
    }
