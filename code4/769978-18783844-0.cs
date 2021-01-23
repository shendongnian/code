    void Main()
    {
        Inject();
    
        Console.WriteLine("Hello Programmers");
    }
    
    public static void Inject()
    {
        Console.SetOut(new InjectedTextWriter(Console.Out));
    }
    
    public class InjectedTextWriter : TextWriter
    {
        private readonly TextWriter _InternalWriter;
    
        public InjectedTextWriter(TextWriter internalWriter)
        {
            _InternalWriter = internalWriter;
        }
    
        public override Encoding Encoding
        {
            get
            {
                return _InternalWriter.Encoding;
            }
        }
    
        public override void Write(string text)
        {
            _InternalWriter.Write(text);
            _InternalWriter.Write(text);
        }
    
        public override void WriteLine(string text)
        {
            _InternalWriter.WriteLine(text);
            _InternalWriter.WriteLine(text);
        }
    }
