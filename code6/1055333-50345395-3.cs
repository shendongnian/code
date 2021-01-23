    using System;
    using System.Reflection;
    using System.IO;
    
    namespace RemoteUser
    {
        public class RemoteUserClass
        {
            public RemoteUserClass()
            {
                // Load the remote assembly
                AssemblyName name = new AssemblyName();
                name.CodeBase = "file://" + Directory.GetCurrentDirectory() + 
                                "ThirdPartyDll.dll";
                Assembly assembly = AppDomain.CurrentDomain.Load(name);
    
                // Instantiate the class
                object remoteObject = 
                  assembly.CreateInstance("ThirdPartyDll.ThirdPartyClass");
                Type remoteType = 
                  assembly.GetType("ThirdPartyDll.ThirdPartyClass");
                
                // Load the enum type
                PropertyInfo flagsInfo = 
                  remoteType.GetProperty("ThirdPartyBitFields");
                Type enumType = assembly.GetType("ThirdPartyDll.BitFields");
    
                // Load the enum values
                FieldInfo enumItem1 = enumType.GetField("AnotherSetting");
                FieldInfo enumItem2 = enumType.GetField("SomethingElse");
    
                // Calculate the new value
                int enumValue1 = (int)enumItem1.GetValue(enumType);
                int enumValue2 = (int)enumItem2.GetValue(enumType);
                int currentValue = (int)flagsInfo.GetValue(remoteObject, null);
                int newValue = currentValue | enumValue1 | enumValue2;
                
                // Store the new value back in Options.FieldFlags
                object newEnumValue = Enum.ToObject(enumType, newValue);
                flagsInfo.SetValue(remoteObject, newEnumValue, null);
    
                // Call the method
                MethodInfo method = remoteType.GetMethod("DoSomeGood");
                method.Invoke(remoteObject, null);
            }
        }
    }
 
