    public class CustomAsyncTimeoutAttribute : AsyncTimeoutAttribute
    {
        public CustomAsyncTimeoutAttribute() : base(Params.TimeOut)
        {}       
    }
