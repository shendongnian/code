    enum VerbConjugationType
    {
        IndicativePresent,
        IndicativeSimplePast,
        ...
    }
    class VerbConjugation
    {
        public VerbConjugationType ConjugationType { get; set; }
        public string FirstPersonSingular { get; set; }
        public string SecondPersonSingular { get; set; }
        public string ThirdPersonSingular { get; set; }
        public string FirstPersonPlural { get; set; }
        public string SecondPersonPlural { get; set; }
        public string ThirdPersonPlural { get; set; }
    }
