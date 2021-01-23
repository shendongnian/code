    public abstract class TextReader : ITextProcessor
    {
        string ITextProcessor.ProcessText(string input)
        {
            Read(input);
            return input;
        }
        bool ITextProcessor.IModifyText
        {
            get { return false; }
        }
        public abstract void Read(string input);
    }
    public abstract class TextModifier : ITextProcessor
    {
        string ITextProcessor.ProcessText(string input)
        {
            return Modify(input);
        }
        bool ITextProcessor.IModifyText
        {
            get { return true; }
        }
        public abstract string Modify(string input);
    }
    public class SampleModifier : TextModifier
    {
        public override string Modify(string input)
        {
            return input + " !MODIFIED!";
        }
    }
    public class SampleReader : TextReader
    {
        public override void Read(string input)
        {
        }
    }
    static void Main(string[] args)
    {
        var lst = new List<ITextProcessor> { new SampleModifier(), new SampleReader() };
        Console.WriteLine("USING MODIFIERS");
        foreach (var a in lst.Where(x => x.IModifyText))
        {
            Console.WriteLine(a.ProcessText("Hi modifier"));
        }
        Console.WriteLine("USING READERS");
        foreach (var a in lst.Where(x => !x.IModifyText))
        {
            Console.WriteLine(a.ProcessText("Hi reader"));
        }
    }
