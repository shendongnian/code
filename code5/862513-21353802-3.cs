    public void AddString(Action<Options> optionConfig)
    {
      var options = new Options();
      optionConfig(options);
    
      // rest of method
    }
