    class Program
    {
        static void Main(string[] args)
        {
            ITextProcessor processor = new FileProcessor();
            string result = processor.ReadText();
            processor.SaveText(result);
    
            ITextProcessor processorTest = new FileProcessorTest();
            if (processorTest is FileProcessorTest)
            {
                 ((FileProcessorTest)processor).testMethod();
            }
        }
    }
