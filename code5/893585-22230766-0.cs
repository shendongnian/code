    class Program
    {
        static void Main(string[] args)
        {
            ITextProcessor processor = new FileProcessor();
            string result = processor.ReadText();
            processor.SaveText(result);
    
    
            ITextProcessor processorTest = new FileProcessorTest();
            // cast processorTest as the specific type to access the extra method
            ((FileProcessorTest)processorTest).testMethod() 
    
        }
    }
