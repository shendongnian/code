    public class HttpException 
    {
        public string Text { get; private set; }
        private readonly Exception ex;
        public string Message { get { return this.ex.message; } }
        public string InnerExceptionMessage { get { return this.ex.... } }
        public string InnerExceptionInnerExceptionMessage { get { return this.ex....} }
 
        public HttpException(string text, Exception ex)
        {
            this.Text = text;
            this.Exception = ex;
        }
    }
