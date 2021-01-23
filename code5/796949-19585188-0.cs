    using System;
    using System.Security.Cryptography.X509Certificates;
    
    namespace ConsoleApplication1
    {
        public class ConsoleApplication1
        {
            [STAThread]
            static void Main(string[] args)
            {
                X509Certificate xcert = null;
                try
                {
                     xcert = X509Certificate.CreateFromSignedFile(args[0]);
                     Console.WriteLine(args[0] + "\t" + xcert.GetName() + "\t" + xcert.GetPublicKeyString());
              }
                catch (Exception e) { Console.WriteLine(args[0] + ": Unable to readDER-encoded signature."); }
            }
        }
    }
