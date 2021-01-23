    class Options
    {
        public enum YesNo
        {
           Yes,
           No
        }
        [Option('p', "prompt", DefaultValue = YesNo.Yes, HelpText = "Prompt the user before exiting the program. (Yes/No)")]
        public YesNo PromptForExit { get; set; }
    }
