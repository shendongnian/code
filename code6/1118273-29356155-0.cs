    using System;
    using System.IO;
    using System.Reflection;
    namespace EmbeddedResourceLauncherDemo
    {
        public class EmbeddedResourceFile : IDisposable
        {
            private readonly string _resourceName;
            private readonly Assembly _callingAssembly;
            public string FilePath { get; private set; }
            public EmbeddedResourceFile(string embeddedResourceName, string targetFilePath)
            {
                _resourceName = embeddedResourceName;
                FilePath = targetFilePath;
                _callingAssembly = Assembly.GetCallingAssembly();
                WriteFileToDisk();
            }
            private void WriteFileToDisk()
            {
                File.Delete(FilePath);
                var stream = _callingAssembly.GetManifestResourceStream(_resourceName);
                if (stream == null)
                {
                    throw new InvalidOperationException(string.Format("Embedded resource not found: {0}", _resourceName));
                }
                var fileStream = new FileStream(FilePath, FileMode.CreateNew);
                for (var i = 0; i < stream.Length; i++)
                {
                    fileStream.WriteByte((byte)stream.ReadByte());
                }
                fileStream.Close();
            }
            public void Dispose()
            {
                File.Delete(FilePath);
            }
        }
    }
