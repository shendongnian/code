    internal class Program
    {
        private static void Main(string[] args)
        {
            var registrationBuilder = new RegistrationBuilder();
            registrationBuilder
                .ForTypesMatching<IClass>(t => FilterOnMetadata(t, MyClassType.TypeOne))
                .ExportInterfaces();
            var assemblyCatalog = new AssemblyCatalog(typeof (MyClassType).Assembly, registrationBuilder);
            var compositionContainer = new CompositionContainer(assemblyCatalog);
            var ic = new TestImportContainer();
            compositionContainer.ComposeParts(ic);
            var count = ic.ImportedParts.Count();
        }
        public static bool FilterOnMetadata(Type t, MyClassType classType)
        {
            var metadataAttribute = 
                (MyMetadataAttribute) t.GetCustomAttributes(true)
                    .SingleOrDefault(at => at is MyMetadataAttribute);
            if (metadataAttribute != null)
                return metadataAttribute.Type == classType;
            return false;
        }
        private sealed class TestImportContainer
        {
            [ImportMany(typeof(IClass))]
            public IEnumerable<IClass> ImportedParts { get; set; }
        }
    }
