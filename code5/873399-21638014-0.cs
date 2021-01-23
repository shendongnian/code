    enum Disposition
    {
        OK,
        Warning,
        Error
    }
    
    class Response<T>
    {
        public T Result { get; set; }
        public Disposition Disposition { get; set; } 
        public string Message { get; set; }
    }
