        public string Optional{ get; set; } = "DefaultValue";
        private readonly string _mandatory;
        public ProblemStatement(string mandatory)
        {
            _mandatory = mandatory;
        }
