        enum VerbConjugationType
        {
            IndicativePresent,
            IndicativeSimplePast,
            ...
        }
        class VerbConjugation
        {
            public VerbConjugationType conjugationType { get; set; }
            public string firstPersonSingular { get; set; }
            public string secondPersonSingular { get; set; }
            public string thirdPersonSingular { get; set; }
            public string firstPersonPlural { get; set; }
            public string secondPersonPlural { get; set; }
            public string thirdPersonPlural { get; set; }
        }
