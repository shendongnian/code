    // Define a class to receive parsed values
    class Options {
        
      [Option('v', "version", 
        HelpText = "Prints version information to standard output.")]
      public bool Version { get; set; }
    
      [ParserState]
      public IParserState LastParserState { get; set; }
    
      [HelpOption]
      public string GetUsage() {
        return HelpText.AutoBuild(this,
          (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
      }
    }
    
    // Consume them
    static void Main(string[] args) {
      var options = new Options();
      if (CommandLine.Parser.Default.ParseArguments(args, options)) {
        // Values are available here
        if (options.Version) Console.WriteLine("Version: {0}", GetVersion());
      }
    }
