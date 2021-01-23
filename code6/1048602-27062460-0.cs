    public interface IFileAccess
    {
         Stream GetFileStream(string fileName);
    }
    public class RealFileAccess : IFileAccess
    {
         public Stream GetFileStream(string fileName)
         {
              ....
         }
    }
    public class ConfigLoader
    {
         Rubberduck.Config.Configuration LoadConfiguration(IFileAccess fileAccess)
         {
              const string configFile = @"C:\Users\Christopher\Source\Repos\RetailCoderVBE\RetailCoder.VBE\Config\rubberduck.config";
              var deserializer = new XmlSerializer(typeof(Rubberduck.Config.Configuration));
            return (Rubberduck.Config.Configuration)deserializer.Deserialize(fileAccess.GetFileStream(configFile));
         }
    }
