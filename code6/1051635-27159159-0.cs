    //the lazy can be changed to an instance variable, if that's appropriate in context.
    private static Lazy<Task<Customer>> lazy = 
        new Lazy<Task<Customer>>(() => GetFromWebService());
    public Task<Customer> GetCustomer(){
       return lazy.Value;
    }
