    public static System.Collections.IEnumerable DynamicSqlQuery(this Database database, string sql, params object[] parameters)
            {
                TypeBuilder builder = createTypeBuilder(
                        "MyDynamicAssembly", "MyDynamicModule", "MyDynamicType");
     
                using (System.Data.IDbCommand command = database.Connection.CreateCommand())
                {
                    try
                    {
                        database.Connection.Open();
                        command.CommandText = sql;
                        command.CommandTimeout = command.Connection.ConnectionTimeout;
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
     
                        using (System.Data.IDataReader reader = command.ExecuteReader())
                        {
                            var schema = reader.GetSchemaTable();
                            
                            foreach (System.Data.DataRow row in schema.Rows)
                            {
                                string name = (string)row["ColumnName"];
                                //var a=row.ItemArray.Select(d=>d.)
                                Type type = (Type)row["DataType"];
                                if(type!=typeof(string) && (bool)row.ItemArray[schema.Columns.IndexOf("AllowDbNull")])
                                {
                                    type = typeof(Nullable<>).MakeGenericType(type);
                                }
                                createAutoImplementedProperty(builder, name, type);
                            }
                        }
                    }
                    finally
                    {
                        database.Connection.Close();
                        command.Parameters.Clear();
                    }
                }
     
                Type resultType = builder.CreateType();
     
                return database.SqlQuery(resultType, sql, parameters);
            }
     
            private static TypeBuilder createTypeBuilder(
                string assemblyName, string moduleName, string typeName)
            {
                TypeBuilder typeBuilder = AppDomain
                    .CurrentDomain
                    .DefineDynamicAssembly(new AssemblyName(assemblyName),
                                           AssemblyBuilderAccess.Run)
                    .DefineDynamicModule(moduleName)
                    .DefineType(typeName, TypeAttributes.Public);
                typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
                return typeBuilder;
            }
     
            private static void createAutoImplementedProperty(
                TypeBuilder builder, string propertyName, Type propertyType)
            {
                const string PrivateFieldPrefix = "m_";
                const string GetterPrefix = "get_";
                const string SetterPrefix = "set_";
     
                // Generate the field.
                FieldBuilder fieldBuilder = builder.DefineField(
                    string.Concat(PrivateFieldPrefix, propertyName),
                                  propertyType, FieldAttributes.Private);
     
                // Generate the property
                PropertyBuilder propertyBuilder = builder.DefineProperty(
                    propertyName, System.Reflection.PropertyAttributes.HasDefault, propertyType, null);
     
                // Property getter and setter attributes.
                MethodAttributes propertyMethodAttributes =
                    MethodAttributes.Public | MethodAttributes.SpecialName |
                    MethodAttributes.HideBySig;
     
                // Define the getter method.
                MethodBuilder getterMethod = builder.DefineMethod(
                    string.Concat(GetterPrefix, propertyName),
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
                    string.Concat(SetterPrefix, propertyName),
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
