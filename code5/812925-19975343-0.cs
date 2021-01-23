    class Program
    {
        static void Main(string[] args)
        {
            var container = new CompositionContainer(new ApplicationCatalog());
            Console.WriteLine("Main: container [{0}]", container.GetHashCode());
            container.ComposeExportedValue<CompositionContainer>(container);
            var exp = container.GetExportedValue<ExportThatNeedsContainer>();
            Console.ReadKey();
        }
    }
    [Export]
    public class ExportThatNeedsContainer
    {
        [ImportingConstructor]
        public ExportThatNeedsContainer(CompositionContainer cc)
        {
            Console.WriteLine("ExportThatNeedsContainer: cc [{0}]", cc.GetHashCode());
        }
    }
