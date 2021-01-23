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
        // These dependencies will be automatically resolved
        // (and in this case supplied to the constructor)
        public Program(IMapper mapper)
        {
            Mapper.RegisterMappings();
        }
    }
