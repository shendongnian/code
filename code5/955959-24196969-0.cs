    var tree = CSharpSyntaxTree.ParseText(@"
    public class MyClass<T> {
        public static T Method()
        {
        }
    }");
    var mscorlib = new MetadataFileReference(typeof(object).Assembly.Location);
    var compilation = CSharpCompilation.Create("MyCompilation",
           syntaxTrees: new[] { tree }, references: new[] { mscorlib });
    var type = compilation.GetTypeByMetadataName("MyClass`1");
