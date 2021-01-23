    public interface IOutputWriter 
    {
        void WriteLine(string s);
    }
    
    // Use this console writer for your live code
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
    }
    
    public abstract class Question
    {
        private readonly IOutputWriter _writer;
        private readonly string _text;
        private readonly bool _default;
    
        public Question(IOutputWriter writer, params object[] args)
        {
            _writer = writer;
            _text = (string)args[0];
            _default = (bool)args[1];
        }
    
        public void Ask()
        {
            _writer.WriteLine(_text);
        }
    }
    
    
    [Test]
    public void QuestionAsk()
        {
            var writer = new Mock<IOutputWriter>();
    
            var mock = new Mock<Question>(writer.Object, new object[]{"question text",true});
            
            mock.CallBase = true;
    
            var Question = mock.Object;
    
            Question.Ask();
    
            mock.Verify(m => m.Ask(), Times.Exactly(1));
            mock.Verify(w => w.WriteLine(It.Is<string>(s => s == "question text")), Times.Once)
    
        }
