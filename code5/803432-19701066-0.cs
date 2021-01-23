    public interface IEditor
    { 
        void Edit(object input);
    }
    
    public class EditorView : IEditor
    {
        public void Edit(object input)
        {
            // open modal window, set DataContext
        }
    }
    
    public class EditorStub : IEditor
    {
        public void Edit(object input)
        {
            // alter the properties of input that you want to simulate user interaction on
        }
    }
