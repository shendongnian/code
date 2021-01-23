    static class ProgramEntry
    {
        static void Main(string[] args)
        {
            var unity = CreateUnityContainerAndRegisterComponents();
            // Explicitly Resolve the "root" component or components
            var program = unity.Resolve<Program>();
            program.Run();
        }
    }
    public class Program
    {
        readonly Ix _x;
        // These dependencies will be automatically resolved
        // (and in this case supplied to the constructor)
        public Program(IMapper mapper, Ix x)
        {
            // Use dependencies
            mapper.RegisterMappings();
            // Assign any relevant properties, etc.
            _x = x;
        }
        // Do actual work here
        public void Run() {
            _x.DoStuff();
        }
    }
