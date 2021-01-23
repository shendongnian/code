    public class RegistrySettings
    {
        public int IncludeComments { get; set; }
        public int RunOcr { get; set; }
    
        private const string ConversionKey = @"HKEY_CURRENT_USER\SOFTWARE\Adobe\Adobe Acrobat\11.0\AVConversionFromPDF\cSettings\c0\cSettings";
        private const string RunOcrValueName = "bRunOCR";
        private const string IncludeCommentsValueName = "bIncludeComments";
    
        public static RegistrySettings CreateWithDisabledOcr()
        {
            return new RegistrySettings() {IncludeComments = 0, RunOcr = 0};
        }
    
        public static RegistrySettings Parse()
        {
            var runOcr = (int) Registry.GetValue(ConversionKey, RunOcrValueName, null);
            var comments = (int) Registry.GetValue(ConversionKey, IncludeCommentsValueName, null);
    
            return new RegistrySettings() {IncludeComments = comments, RunOcr = runOcr};
        }
    
        public void Save()
        {
            Registry.SetValue(ConversionKey, RunOcrValueName, RunOcr);
            Registry.SetValue(ConversionKey, IncludeCommentsValueName, IncludeComments);
        }
    }
