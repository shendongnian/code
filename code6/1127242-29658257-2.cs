    [Flags]
    public enum Operations
    {
        TextFormatting = 1,
        SpellChecking = 2,
        Translation = 4
    }
    
    public class TextProcessingParameters
    {
        public IEnumerable<Operations> OperationSets { get; set; }
        // other parameters, including parameters for different operations
    }
