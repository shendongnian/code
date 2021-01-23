    using System.Linq;
    public class StringReverser
    {
        IMyLogger _log;
        public StringReverser(IMyLogger logger)
        {
           _log = logger;
        }
         public string Reverse(string text)
         {
            _log.WriteLine("MyFunction: " + DateTime.Now);
            _log.WriteLine("text (string) argument: " + text);
            string result = null;
            if (text != null)
                result = new string(text.Reverse().ToArray());
            _log.WriteLine("Return value: " + result);
           return result;
       }
