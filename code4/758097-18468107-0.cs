    public class SourceClass
    {
        public Int32 first = 1;
        public Int32 second = 2;
        public Int32 third = 3;
    }
    public static class MyConvert
    {
        public static object ToDynamic(object sourceObject, out Type outType)
        {
            Int32 fieldOffset = 0;
            // get the public fields from the source object
            FieldInfo[] sourceFields = sourceObject.GetType().GetFields();
            // get a dynamic TypeBuilder and inherit from the base type
            AssemblyName assemblyName
                = new AssemblyName("MyDynamicAssembly");
            AssemblyBuilder assemblyBuilder
                = AppDomain.CurrentDomain.DefineDynamicAssembly(
                    assemblyName,
                    AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder
                = assemblyBuilder.DefineDynamicModule("MyDynamicModule");
            TypeBuilder typeBuilder
                = moduleBuilder.DefineType(
                    "InternalType",
                    TypeAttributes.Public
                    | TypeAttributes.Class
                    | TypeAttributes.AutoClass
                    | TypeAttributes.AnsiClass
                    | TypeAttributes.ExplicitLayout,
                    typeof(SomeOtherNamespace.MyBase));
            // add public fields to match the source object
            foreach (FieldInfo sourceField in sourceFields)
            {
                FieldBuilder fieldBuilder
                    = typeBuilder.DefineField(
                        sourceField.Name,
                        sourceField.FieldType,
                        FieldAttributes.Public);
                fieldBuilder.SetOffset(fieldOffset);
                fieldOffset++;
            }
            // create the dynamic class
            Type dynamicType = typeBuilder.CreateType();
            // create an instance of the class
            object destObject = Activator.CreateInstance(dynamicType);
            // copy the values of the public fields of the
            // source object to the dynamic object
            foreach (FieldInfo sourceField in sourceFields)
            {
                FieldInfo destField
                    = destObject.GetType().GetField(sourceField.Name);
                destField.SetValue(
                    destObject,
                    sourceField.GetValue(sourceObject));
            }
            // give the new class to the caller for casting purposes
            outType = dynamicType;
            // return the new object
            return destObject;
        }
