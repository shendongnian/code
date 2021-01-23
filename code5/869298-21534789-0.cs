    abstract class VerbConjugation {}
    class StandardConjugation : VerbConjugation {
      public string firstPersonSingular { get; set; }
      public string secondPersonSingular { get; set; }
      public string thirdPersonSingular { get; set; }
      public string firstPersonPlural { get; set; }
      public string secondPersonPlural { get; set; }
      public string thirdPersonPlural { get; set; }
    }
    class IndicativePresent : StandardConjugation {}
    class IndicativeSimplePast : StandardConjugation {}
    class IndicativePresentPerfect : StandardConjugation {}
    class Imperative : VerbConjugation 
    {
        public string secondPersonSingular { get; set; }
        public string firstPersonPlural { get; set; }
        public string secondPersonPlural { get; set; }
    }
    class ImperativePast: Imperative {}
    class ImperativePresent: Imperative {}
    class Participle : VerbConjugation
    {
      public string present { get; set; }
      public string past { get; set; }
    }
