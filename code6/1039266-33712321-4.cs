    public static class DatabaseExtension
    {
        public static IEnumerable<T> DynamicSqlQuery<T>(this Database database, string[] fields, string sql, params object[] parameters) where T : new()
        {
            var type = typeof (T);
            var builder = CreateTypeBuilder("MyDynamicAssembly", "MyDynamicModule", "MyDynamicType");
            foreach (var field in fields)
            {
                var prop = type.GetProperty(field);
                var propertyType = prop.PropertyType;
                CreateAutoImplementedProperty(builder, field, propertyType);
            }
            var resultType = builder.CreateType();
      
            var items = database.SqlQuery(resultType, sql, parameters);
            foreach (object item in items)
            {
                var obj = new T();
                var itemType = item.GetType();
                foreach (var prop in itemType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    var name = prop.Name;
                    var value = prop.GetValue(item, null);
                    type.GetProperty(name).SetValue(obj, value);
                }
                yield return obj;
            }
        }
        private static TypeBuilder CreateTypeBuilder(string assemblyName, string moduleName, string typeName)
        {
            TypeBuilder typeBuilder = AppDomain
                .CurrentDomain
                .DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.Run)
                .DefineDynamicModule(moduleName)
                .DefineType(typeName, TypeAttributes.Public);
            typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            return typeBuilder;
        }
        private static void CreateAutoImplementedProperty(TypeBuilder builder, string propertyName, Type propertyType)
        {
            const string privateFieldPrefix = "m_";
            const string getterPrefix = "get_";
            const string setterPrefix = "set_";
            // Generate the field.
            FieldBuilder fieldBuilder = builder.DefineField(
                string.Concat(privateFieldPrefix, propertyName),
                              propertyType, FieldAttributes.Private);
            // Generate the property
            PropertyBuilder propertyBuilder = builder.DefineProperty(
                propertyName, PropertyAttributes.HasDefault, propertyType, null);
            // Property getter and setter attributes.
            MethodAttributes propertyMethodAttributes =
                MethodAttributes.Public | MethodAttributes.SpecialName |
                MethodAttributes.HideBySig;
            // Define the getter method.
            MethodBuilder getterMethod = builder.DefineMethod(
                string.Concat(getterPrefix, propertyName),
                propertyMethodAttributes, propertyType, Type.EmptyTypes);
            // Emit the IL code.
            // ldarg.0
            // ldfld,_field
            // ret
            ILGenerator getterILCode = getterMethod.GetILGenerator();
            getterILCode.Emit(OpCodes.Ldarg_0);
            getterILCode.Emit(OpCodes.Ldfld, fieldBuilder);
            getterILCode.Emit(OpCodes.Ret);
            // Define the setter method.
            MethodBuilder setterMethod = builder.DefineMethod(
                string.Concat(setterPrefix, propertyName),
                propertyMethodAttributes, null, new Type[] { propertyType });
            // Emit the IL code.
            // ldarg.0
            // ldarg.1
            // stfld,_field
            // ret
            ILGenerator setterILCode = setterMethod.GetILGenerator();
            setterILCode.Emit(OpCodes.Ldarg_0);
            setterILCode.Emit(OpCodes.Ldarg_1);
            setterILCode.Emit(OpCodes.Stfld, fieldBuilder);
            setterILCode.Emit(OpCodes.Ret);
            propertyBuilder.SetGetMethod(getterMethod);
            propertyBuilder.SetSetMethod(setterMethod);
        }    
    }
