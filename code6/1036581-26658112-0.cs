    using System.Speech.Synthesis;
    
    static void Main(string[] args)
    {
       ...
       // Speech helper
       SpeechSynthesizer reader = new SpeechSynthesizer();
       const string msg = "Hello";
       Console.WriteLine(msg);
       reader.SpeakAsync(msg);
    }
