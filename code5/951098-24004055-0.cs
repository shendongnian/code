        public static class TypeBuilderUtil {
            public static Type BuildDynamicType() {
                var typeBuilder = CreateTypeBuilder( "DynamicType" );
                CreateProperty( typeBuilder, "Property1", typeof ( string ) );
                var objectType = typeBuilder.CreateType();
                return objectType;
            }
            private static TypeBuilder CreateTypeBuilder( string typeName ) {
                var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly( new AssemblyName( "DynamicAssembly" ), AssemblyBuilderAccess.Run );
                var moduleBuilder = assemblyBuilder.DefineDynamicModule( "DynamicModule" );
                var typeBuilder = moduleBuilder.DefineType( typeName,
                                                            TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout
                                                            , null );
                return typeBuilder;
            }
            private static void CreateProperty( TypeBuilder typeBuilder, string propertyName, Type propertyType ) {
                var backingFieldBuilder = typeBuilder.DefineField( "_" + propertyName, propertyType, FieldAttributes.Private );
                var propertyBuilder = typeBuilder.DefineProperty( propertyName, PropertyAttributes.HasDefault, propertyType, null );
                // Build setter
                var getterMethodBuilder = typeBuilder.DefineMethod( "get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes );
                var getterIl = getterMethodBuilder.GetILGenerator();
                getterIl.Emit( OpCodes.Ldarg_0 );
                getterIl.Emit( OpCodes.Ldfld, backingFieldBuilder );
                getterIl.Emit( OpCodes.Ret );
                // Build setter
                var setterMethodBuilder = typeBuilder.DefineMethod( "set_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] {propertyType} );
                var setterIl = setterMethodBuilder.GetILGenerator();
                setterIl.Emit( OpCodes.Ldarg_0 );
                setterIl.Emit( OpCodes.Ldarg_1 );
                setterIl.Emit( OpCodes.Stfld, backingFieldBuilder );
                setterIl.Emit( OpCodes.Ret );
                propertyBuilder.SetGetMethod( getterMethodBuilder );
                propertyBuilder.SetSetMethod( setterMethodBuilder );
            }
        }
