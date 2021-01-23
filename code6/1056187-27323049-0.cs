	class Program
    {
        static void Main(string[] args)
        {
            Converter.Convert("input", "output", new FormatA());
            Converter.Convert("input", "output", new FormatB());
        }
    }
	
	class Converter
    {
        public static void Convert<T>(string inputFile, string outputFile, T formatter) where T : IConvertFormat
        {
            // First variant: Keep the functionality in the formatter object
            formatter.DoSomething(inputFile, outputFile);
            // Second variant: check for the actual type
            if (formatter is FormatA)
            {
                // ... do format A
            }
            else if (formatter is FormatB)
            {
                // ... do format B
            }
        }
    }
	
	interface IConvertFormat
    {
        // Method not required for variant 2
        void DoSomething(string inputFile, string outputFile);
    }
	
    class FormatA : IConvertFormat
    {
        public void DoSomething(string inputFile, string outputFile)
        {
            // .. do it like Format A (not required for variant 2)
        }
    }
	class FormatB : IConvertFormat
    {
        public void DoSomething(string inputFile, string outputFile)
        {
            // do it like Format B (not required for variant 2)
        }
    }
	
