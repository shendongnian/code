    namespace ConsoleApp1
    {
        using System.Diagnostics;
        using System.IO;
        using System.Security.Cryptography.X509Certificates;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Serialization;
        class Program
        {
            static void Main(string[] args)
            {
                var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                try
                {
                    store.Open(OpenFlags.ReadOnly);
                    var cert = store.Certificates[0];
                    var path = Path.GetTempFileName();
                    File.WriteAllText(
                        path,
                        JsonConvert.SerializeObject(
                            cert, new JsonSerializerSettings {
                                Formatting = Formatting.Indented,
                                // Ignore serializtion errors
                                Error = (s, a) => a.ErrorContext.Handled = true,
                                ContractResolver = new DefaultContractResolver {
                                    // Ensures all properties are serialized
                                    IgnoreSerializableInterface = true
                                }
                            }
                        )
                    );
                    Process.Start(path);
                }
                finally
                {
                    store.Close();
                }
            }
        }
    }
