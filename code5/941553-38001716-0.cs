        [System.Windows.Markup.ConstructorArgument(nameof(Second))]
        public string Second { get; set; } = "DefaultValue";
        private readonly string _first;
        public ProblemStatement(string first)
        {
            _first = first;
        }
