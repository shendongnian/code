    using System;
    using PCSC;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var context = new SCardContext();
                context.Establish(SCardScope.System);
    
                var readerNames = context.GetReaders();
                if (readerNames == null || readerNames.Length < 1)
                {
                    Console.WriteLine("You need at least one reader in order to run this example.");
                    Console.ReadKey();
                    return;
                }
    
                foreach (var readerName in readerNames)
                {
                    var reader = new SCardReader(context);
    
                    Console.Write("Trying to connect to reader.. " + readerName);
    
                    var rc = reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
                    if (rc != SCardError.Success)
                    {
                        Console.WriteLine(" failed. No smart card present? " + SCardHelper.StringifyError(rc) + "\n");
                    }
                    else
                    {
                        Console.WriteLine(" done.");
    
                        byte[] attribute = null;
                        rc = reader.GetAttrib(SCardAttribute.VendorInterfaceDeviceTypeVersion, out attribute);
                        if (rc != SCardError.Success)
                            Console.WriteLine("Error by trying to receive attribute. {0}\n", SCardHelper.StringifyError(rc));
                        else
                            Console.WriteLine("Attribute value: {0}\n", BitConverter.ToString(attribute ?? new byte[] { }));
    
                        reader.Disconnect(SCardReaderDisposition.Leave);
                    }
                }
    
                context.Release();
                Console.ReadKey();
            }
        }
    }
