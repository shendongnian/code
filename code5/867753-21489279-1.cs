      public class XYZSerializationBinder : SerializationBinder
      {
        public override Type BindToType(string assemblyName, string typeName)
        {
          Type curType = null;
          //if object was serialized with previous version .dll, deserialze with current version .dll (only relevant with strong names)
          if (!string.IsNullOrEmpty(assemblyName) && assemblyName.Contains("Culture=neutral")
            && (assemblyName.StartsWith("XYZ.")))
          {
            string plainAssemblyName = assemblyName.Split(',')[0];
            Assembly ass = Assembly.Load(plainAssemblyName);
            curType = ass.GetType(typeName);
          }
          else
          {
            curType = Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
          }
          if (curType == null)
          {
            return typeof(InvalidType);
          }
          return curType;
        }
      }
