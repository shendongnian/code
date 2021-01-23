    public void ExampleMethod(int required, string optionalstr = "default string")
    {
         //When this method called, means optionalint was NOT passed
    }
    public void ExampleMethod(int required, string optionalstr = "default string",
        int optionalint)
    {
        //When this method called, means optionalint was passed
    }
