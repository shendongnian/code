    class Options
    {
        private static string LicenseTypeHelp = "License type (" + string.Join(", ", Enum.GetNames(typeof(CompanyLicenseType))) + ").";
        [Option('t', "license-type", Required = true, HelpText = "License type.")]
        public CompanyLicenseType LicenseType { get; set; }    
    
        [HelpOption('h', "help", HelpText = "Dispaly this help screen.")]
        public string GetUsage()
        {
            string helpText = HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            return helpText.Replace("License type.", LicenseTypeHelp);
        }
    }
