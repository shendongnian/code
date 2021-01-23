        public void Serialize(string OutPath, Dictionary<string, object> Input) {
            //Define stuff
            AssemblyName assName = new AssemblyName("CustomType");
            AssemblyBuilder assBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder modBuilder = assBuilder.DefineDynamicModule(assName.Name);
            TypeBuilder typBuilder = modBuilder.DefineType("NewType", TypeAttributes.Public);
            //Add all the keys as fields
            foreach (string Key in Input.Keys) {
                typBuilder.DefineField(Key, Input[Key].GetType(), FieldAttributes.Public);
            }
            //Make the new type
            Type newType = typBuilder.CreateType();
            //make instance
            object newInstance = Activator.CreateInstance(newType);
            //set Values
            foreach (string Key in Input.Keys) {
                newInstance.GetType().GetField(Key).SetValue(newInstance, Input[Key]);
            }
            //serialize XML
            XmlSerializer xs = new XmlSerializer(newType);
            TextWriter tw = new StreamWriter(OutPath);
            xs.Serialize(tw, newInstance);
            tw.Flush();
            tw.Close();
        }
