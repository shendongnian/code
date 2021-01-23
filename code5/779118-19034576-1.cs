    class MyHttpException : Exception
    {
        public HttpError HttpErrorObject { get; set; }
        public MyHttpException(string Message, HttpError ErrorObject)
            : base(Message)
        {
            this.HttpErrorObject = ErrorObject;
        }
    }
