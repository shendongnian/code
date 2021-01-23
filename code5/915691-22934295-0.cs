    using Microsoft.Win32;
    using System;
    using System.Runtime.InteropServices;
    
    namespace ManagedServer
    {
        [ComVisible(true), Guid("1891CF89-1282-4CA8-B7C5-F2608AF1E2F1")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        public interface IManagedComObject
        {
            string ComMethod(string data);
        }
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        [ComDefaultInterface(typeof(IManagedComObject))]
        [Guid("989162CD-A6A6-4A7D-A7FB-C94086A4E90A")]
        [ProgId("Noseratio.ManagedComObject")]
    
        public class ManagedComObject : IManagedComObject
        {
            // public constructor
            public ManagedComObject()
            {
            }
    
            // IManagedComObject
            public string ComMethod(string data)
            {
                return data;
            }
    
            // registration
            [ComRegisterFunction()]
            public static void Register(Type type)
            {
                var guid = type.GUID.ToString("B");
                using (var appIdKey = Registry.ClassesRoot.CreateSubKey(@"AppID\" + guid))
                {
                    appIdKey.SetValue("DllSurrogate", String.Empty);
                }
                using (var appIdKey = Registry.ClassesRoot.CreateSubKey(@"CLSID\" + guid))
                {
                    appIdKey.SetValue("AppId", guid);
                }
            }
    
            [ComUnregisterFunction()]
            public static void Unregister(Type type)
            {
                var guid = type.GUID.ToString("B");
                using (var appIdKey = Registry.ClassesRoot.OpenSubKey(@"AppID\" + guid, writable: true))
                {
                    if (appIdKey != null)
                        appIdKey.DeleteValue("DllSurrogate", throwOnMissingValue: false);
                }
                Registry.ClassesRoot.DeleteSubKeyTree(@"CLSID\" + guid, throwOnMissingSubKey: false);
            }
        }
    }
