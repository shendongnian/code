    using System.IO;
    ....
    string xmlString = ds.GetXml();
    string path = "Output.xml";
    using(StreamWriter writer = new StreamWriter(path);
    {
        writer.Write(xmlString);
    }
