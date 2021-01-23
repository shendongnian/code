    public class SerializerTypeSurrogate : IDataContractSurrogate
    		{
    			public virtual Type GetDataContractType(Type type)
    			{
    				return type == typeof(Charge) ? typeof(OldCharge) : type;
    			}
    
    			public object GetObjectToSerialize(object obj, Type targetType)
    			{
    				return obj;
    			}
    
    			public virtual object GetDeserializedObject(Object obj, Type targetType)
    			{
    			    var oldClass1= obj as OldClass1;
                            return oldClass1 != null ? new Class1(oldClass1) : obj;
			}
    			
    			public Type GetReferencedTypeOnImport(string typeName,
    				string typeNamespace, object customData)
    			{
    				return null;
    			}
    
    			public System.CodeDom.CodeTypeDeclaration ProcessImportedType(
    				System.CodeDom.CodeTypeDeclaration typeDeclaration,
    				System.CodeDom.CodeCompileUnit compileUnit)
    			{
    				return typeDeclaration;
    			}
    
    
    
    			public object GetCustomDataToExport(Type clrType, Type dataContractType)
    			{
    				return null;
    			}
    
    			public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
    			{
    				return null;
    			}
    
    			public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
    			{
    			}
    		}
