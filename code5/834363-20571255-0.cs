     var assembly = new AssemblyName("FieldTypes");
     AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
     ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assembly.Name);
     TypeBuilder typeBuilder = moduleBuilder.DefineType("DataObjects", TypeAttributes.Public | TypeAttributes.AutoClass | 
         TypeAttributes.AnsiClass |TypeAttributes.BeforeFieldInit, typeof(System.Object));
     foreach (var dataObject in layout.DatabaseInstance.DataSourceObjects)
     {
         FieldBuilder fieldBuilder = typeBuilder.DefineField(dataObject.TableName + "X", typeof(System.String), FieldAttributes.Private);
         PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(dataObject.TableName, PropertyAttributes.HasDefault, typeof(System.String), null);
         MethodBuilder propertyGetter = typeBuilder.DefineMethod("get_" + dataObject.TableName, MethodAttributes.Public | 
             MethodAttributes.SpecialName |MethodAttributes.HideBySig, typeof(System.String), Type.EmptyTypes);
         ILGenerator randomPropertyGetterIL = propertyGetter.GetILGenerator();
         randomPropertyGetterIL.Emit(OpCodes.Ldarg_0);
         randomPropertyGetterIL.Emit(OpCodes.Ldfld, fieldBuilder);
         randomPropertyGetterIL.Emit(OpCodes.Ret);
         propertyBuilder.SetGetMethod(propertyGetter);
     }
     Type randomType = typeBuilder.CreateType();
     binding.DataSource = Activator.CreateInstance(randomType);
