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
    ...
            /// Insert XML elements and attributes into the generated .wxs file
            static void InjectXMLElement(System.Xml.Linq.XDocument document)
            {
                // Remove the <CreateFolder /> tag from Directory element -- we don't want to create it
                var createFolderElement = document.Root.Select("Product/Directory/Directory/Component/CreateFolder");
                createFolderElement.Remove();
                // To cause the folder to not be created on the target system, add this element:
                // <RemoveFolder Id="RemoveTarget" Directory="TARGETDIR" On="both"/>
                var componentElement = document.Root.Select("Product/Directory/Directory/Component");
                
                componentElement.Add(new XElement("RemoveFolder",
                           new XAttribute("Id", "RemoveTarget"),
                           new XAttribute("Directory", "TARGETDIR"),
                           new XAttribute("On","both")));
            }
