    public interface ITestableTextProcessor : ITextProcessor
    {
        void TestMethod();
    }
    public class FileProcessorTest : ITestableTextProcessor {...}
