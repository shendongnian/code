	var tree = CSharpSyntaxTree.ParseText(@"
	public class Sample
	{
		public string FooProperty {get; set;}
	   public void FooMethod()
	   {
	   }
	}");
	var properties = tree.GetRoot().DescendantNodes().OfType<PropertyDeclarationSyntax>();
	foreach (var property in properties)
	{
		Console.WriteLine("Property: " + property.Identifier);
	}
	var methods = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>();
	foreach(var method in methods)
	{
		Console.WriteLine("Method: " + method.Identifier);
	}
