    class Question
    {
        public string Name { get; set; }
        public string QuestionFormat { get; set; }
        public List<Range> Args { get; set; }
        public Expression<Func<int[], int>>  ValExp { get; set; }
        public Question(string name, string questionFormat)
        {
            this.Name = name;
            this.QuestionFormat = questionFormat;
            this.Args = new List<Range>();
        }
        public Question Rand(int min, int max)
        {
            this.Args.Add(new Range(min, max));
            return this;
        }
        public void Val(Expression<Func<int[], int>> exp)
        {
            this.ValExp = exp;
        }
        public CompiledQuestion Compile()
        {
            // Generate args in the appropriate ranges
            // Evaluate the result with the ValExp
            // Return a new CompiledQuestion with the information -
            //    basically just replacing Args, ValExp with RealArgs, Val
        }
        public ICoolDataObject Save()
        {
        }
        public static Question Load(ICoolDataObject hmm)
        {
        }
    }
    class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public Range(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }
    }
