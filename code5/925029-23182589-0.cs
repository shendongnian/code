    // using System.Reflection, System.IO, System.Xml
    
    var asm = Assembly.GetExecutingAssembly();
    var textStream = asm.GetManifestResourceStream('resoucename.xml');
    var xmlReader = new XmlReader(textStream);
    ...
