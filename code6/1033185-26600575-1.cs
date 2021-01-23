    internal class Script
    {
        public static void Main()
        {
            // Define a new Installer Project object
            var project = new Project("SetupMyApplicationEventLog" ,
            // Provide dummy "Temp" install directory to satisfy WiX# Syntactical requirement. There are no actual files being installed.
            new Dir(@"TempDeleteMe"),
...
            // Hook up a delegate to the "WixSourceGenerated" event, fires when .wxs file is fully created
            Compiler.WixSourceGenerated += InjectXMLElement;
            // Trigger the MSI file build
            Compiler.BuildMsi(project);
