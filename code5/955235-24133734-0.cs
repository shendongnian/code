    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.ComponentModel.Composition;
    using System.Reflection;
    namespace SO24132313
    {
        public interface IFoo
        {
            string Name { get; }
        }
        public interface IFooMeta
        {
            string CompType { get; }
        }
        [ExportMetadata("CompType", "Foo1")]
        [Export(typeof(IFoo)), PartCreationPolicy(CreationPolicy.NonShared)]
        public class Foo1 : IFoo
        {
            public string Name
            {
                get { return GetType().ToString(); }
            }
        }
        class PartsManager
        {
            [ImportMany]
            private IEnumerable<ExportFactory<IFoo, IFooMeta>> factories;
            public PartsManager()
            {
                ConstructContainer(this);
            }
            private static void ConstructContainer(PartsManager p)
            {
                var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                var c = new CompositionContainer(catalog);
                c.ComposeParts(p);
            }
            public IFoo GetPart(string compType)
            {
                var matchingFactory = factories.FirstOrDefault(
                    x => x.Metadata.CompType == compType);
                if (factories == null)
                {
                    return null;
                }
                else
                {
                    IFoo foo = matchingFactory.CreateExport().Value;
                    return foo;
                }
            }
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                PartsManager a = new PartsManager();
                IFoo bla = a.GetPart("Foo1");
                Console.WriteLine(bla);
            }
        }
    }
