    public sealed class DerivedTool : IToolWrapper {
        private Tool _tool;
        public DerivedTool(String filename) : base() {
            _tool = LoadFromFile(filename) as Tool;
        }
        public static implicit operator Tool(DerivedTool dt)
        {
            return dt._tool;
        }
    }
