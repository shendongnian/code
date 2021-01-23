    struct Calculator
    {
        // Properties for returning addition numbers 
        public static long AddNumberOne { get; set; }
        public static long AddNumberTwo { get; set; }
    
        // Properties for returning multiplication numbers 
        public static long MulNumberOne { get; set; }
        public static long MulNumberTwo { get; set; }
    
        // Properties for returning division numbers  { get; set; }
        public static double DivNumberTwo { get; set; }
    
        // Properties for returning minus numbers 
        public static double MinNumberOne { get; set; }
        public static double MinNumberTwo { get; set; }
    
        // Property for returning program run state 
        public static bool RunProgram { get; set; }
    
        // Properties for returning total after calculation is made 
        public static long TotalAddition { get; set; }
        public static long TotalMultiply { get; set; }
        public static double TotalDivide { get; set; }
        public static double TotalMinus { get; set; }
    
        // Properties for user input
        public static string InputOption { get; set; }
        public static long InputConversion { get; set; }
    
        // METHODS
    }
