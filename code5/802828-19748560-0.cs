    class Program
    {
        static void Main()
        {
            // importing class instance
            var mcc = new MyClassConsumer();
            // type to export
            var typeToExport = typeof(MyClassA);
            Console.WriteLine("Type to export: {0}", typeToExport);
            var rb = new RegistrationBuilder();
            rb.ForType(typeToExport)
                .ExportInterfaces();
            var catalog = new AssemblyCatalog(typeof(Program).Assembly, rb);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(mcc); // bombs if MyClassA's MetadataAttribute is not commented out
            Console.WriteLine("Imported property's type: {0}", mcc.MyClass.GetType());
            Console.ReadLine();
        }
    }
    public enum MyClassType { TypeA, TypeB }
    public interface IClass {}
    public interface IClassMetaData { MyClassType Type { get; } }
    [ExportMetadata("Type", MyClassType.TypeA)] // works if you comment this line
    public class MyClassA : IClass
    {
    }
    [ExportMetadata("Type", MyClassType.TypeB)]
    public class MyClassB : IClass
    {
    }
    public class MyClassConsumer
    {
        [Import]
        public IClass MyClass { get; set; }
    }
