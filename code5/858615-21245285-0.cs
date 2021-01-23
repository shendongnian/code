    public partial class Customer()
    {
        partial void OnCodeChanging(string value) 
        {
            if(string.IsNullOrEmpty(value))
                throw new InvalidOperationException ("value cannot be null or empty");
        }
    }
