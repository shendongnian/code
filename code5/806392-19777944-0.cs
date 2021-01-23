    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    
    namespace ConsoleApplication3
    {
        public enum URLZONE : uint
        {
            URLZONE_LOCAL_MACHINE = 0,
            URLZONE_INTRANET = 1,
            URLZONE_TRUSTED = 2,
            URLZONE_INTERNET = 3,
            URLZONE_UNTRUSTED = 4,
        }
    
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("cd45f185-1b21-48e2-967b-ead743a8914e")]
        public interface IZoneIdentifier
        {
            URLZONE GetId();
            void SetId(URLZONE zone);
            void Remove();
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                object persistZoneId = Activator.CreateInstance(Type.GetTypeFromCLSID(Guid.Parse("0968e258-16c7-4dba-aa86-462dd61e31a3")));
                IZoneIdentifier zoneIdentifier = (IZoneIdentifier)persistZoneId;
                IPersistFile persisteFile = (IPersistFile)persistZoneId;
                zoneIdentifier.SetId(URLZONE.URLZONE_UNTRUSTED);
                persisteFile.Save(@"c:\temp\test.txt", false);
            }
        }
    }
