    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    namespace MyMEF
    {
    
        [Export]
        public class Class1 : MefContracts.IHost
        {
            public String Version
            {
                get { return "v1.00"; }
            }
        }
    
        class clsMEF
        {
            private CompositionContainer _container;
    
            [Import(typeof(MefContracts.IPlugin))]
            public MefContracts.IPlugin plugin;
    
            public clsMEF()
            {
                Compose();
            }
      
            void Compose()
            {
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new DirectoryCatalog("..\\..\\Extensions"));
                catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly())); // <-- THIS WAS THE MISSING PIECE
                _container = new CompositionContainer(catalog);
                try
                {
                    this._container.ComposeParts(this);
                }
                catch (CompositionException compositionException)
                {
                    Console.WriteLine(compositionException.ToString());
                }
    
            }
        }
        static class Program
        {
            static void Main()
            {
                clsMEF myMef = new clsMEF();
                MessageBox.Show(myMef.plugin.Work("Tedst"));
            }
        }
    }
