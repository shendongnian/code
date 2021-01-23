    class Program
    {
        static void Main()
        {
            var catalog = new AssemblyCatalog(typeof(Program).Assembly);
            var filteredCatalog = catalog.Filter(p =>
                {
                    var type = ReflectionModelServices.GetPartType(p).Value;
                    return typeof(IClass).IsAssignableFrom( type ) && // implements interface you're looking for
                        Attribute.IsDefined(type, typeof(ExportMetadataAttribute)) && // has ExportMetadata attribute
                        // check for Type == MyClassType.TypeA
                        type.GetCustomAttributes(typeof(ExportMetadataAttribute), true).Any(ca =>
                            {
                                var ema = (ExportMetadataAttribute)ca;
                                return ema.Name == "Type" && (MyClassType)ema.Value == MyClassType.TypeA;
                            });
                });
            var container = new CompositionContainer(filteredCatalog);
            MyClassConsumer mcc = new MyClassConsumer();
            container.ComposeParts(mcc);
            Console.WriteLine("Imported property's type: {0}", mcc.MyClass.GetType());
            Console.ReadLine();
        }
    }
    
    public enum MyClassType { TypeA, TypeB }
    public interface IClass {}
    public interface IClassMetaData { MyClassType Type { get; } }
    
    [Export(typeof(IClass))]
    [ExportMetadata("Type", MyClassType.TypeA)]
    public class MyClassA : IClass
    {
    }
    [Export(typeof(IClass))]
    [ExportMetadata("Type", MyClassType.TypeB)]
    public class MyClassB : IClass
    {
    }
    public class MyClassConsumer
    {
        [Import]
        public IClass MyClass { get; set; }
    }
