            class FindFile
            {
                private static string fullName;
                public static string FullName
                {
                    get 
                    {
                        if (fullName == null)
                             throw new FullNameNotInitialized();
                        return fullName;  
                    }
                    set 
                    { 
                        fullName = value; 
                    }
                }
 
    public class FullNameNotInitialized : Exception
    {
    public FullNameNotInitialized()
    : base() { }
    public FullNameNotInitialized(string message)
        : base(message) { }
    public FullNameNotInitialized(string format, params object[] args)
        : base(string.Format(format, args)) { }
    public FullNameNotInitialized(string message, Exception innerException)
        : base(message, innerException) { }
    public FullNameNotInitialized(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }
    protected FullNameNotInitialized(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
