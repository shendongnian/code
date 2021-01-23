    void WriteConditional(Func<string> retriever, string format)
    {
       var value = retriever();
       if(string.IsNullOrEmpty(value)==false)
          Console.WriteLine(string.Format(format,value));
    }
    
    void WriteConditional(string value, string format)
    {
       WriteConditional(() => value, format);
    }
