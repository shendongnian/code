    TextWriter oldWriter = Console.Error;
    ErrorCapturer errorCapturer = new ErrorCapturer();
    Console.SetError(errorCapturer);
    Console.Error.WriteLine("An error has occured");
    string error = errorCapturer.ReadToEnd();
    Console.SetError(oldWriter);
    class ErrorCapturer : TextWriter
    {
        string _buffer="";
        public override void WriteLine(string line)
        {
            _buffer += line + Environment.NewLine;
            base.WriteLine(line);
        }
        public string ReadToEnd()
        {
            string ret = _buffer;
            _buffer = "";
            return ret;
        }
        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
