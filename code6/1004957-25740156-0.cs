    public interface ITextOperator {
      void Execute(string text);
    }
    
    public interface ITextWriter : ITextOperator {
      string Result { get; }
    }
    public class TextReader : ITextOperator {
      public void Execute(string text) {
        // do something with text
      }
    }
    public class TextWriter : ITextWriter {
      public void Execute(string text) {
        // do something with text
        // store result in Result property
      }
      public string Result { get; private set; }
    }
