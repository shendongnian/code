    object GetValue64Or32(string path, string ValueKey)
    {
         var parts = path.Split('\\');
         RegistryHive hive = RegistryHive.LocalMachine;
         switch(parts[0])
         {
            case "HKEY_LOCAL_MACHINE":
                hive = RegistryHive.LocalMachine;
            break;
            default:
               throw new NotImplementedException();
         }
         foreach(var view in Enum.GetValues(typeof(RegistryView)))
         {
            var key = RegistryKey.OpenBaseKey(hive, (RegistryView) view);
            for(var partIndex=1; partIndex<parts.Length;partIndex++)
            {
               key = key.OpenSubKey(parts[partIndex]);
               if (key == null) break;
            }
            if (key!=null) return key.GetValue(ValueKey);
         }
         return null;
    }
