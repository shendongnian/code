    class Options
    {
        [Option('p', "do-not-prompt", DefaultValue = false, HelpText = "Do not prompt the user before exiting the program.")]
        public bool DoNotPromptForExit { get; set; }
    
        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
    static void Main(string[] args)
    {
        Options options = new Options();
        if (CommandLine.Parser.Default.ParseArguments(args, options))
        {
            if (!options.DoNotPromptForExit)
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
