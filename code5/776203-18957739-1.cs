	using System;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.Serialization;
	
	namespace ReactiveUI.Ext
	{
	    class ImmutableListListConverter<T>
	    {
	        public static ImmutableList<T> ToImmutable( List<T> list )
	        {
	            return ImmutableList<T>.Empty.AddRange(list);
	        }
	
	        public static List<T> ToList(ImmutableList<T> list){
	            return list.ToList();
	        }
	        
	    }
	
	    public class ImmutableSurrogateSerializer : IDataContractSurrogate
	    {
	        public Type GetDataContractType( Type type )
	        {
	            if(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ImmutableList<>)) 
	            {
	                var listType = typeof(List<>);
	                return listType.MakeGenericType(type.GetGenericArguments());
	            }
	            else
	            {
	                return type;
	            }
	        }
	
	        public object GetDeserializedObject( object obj, Type targetType )
	        {
	            if(targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(ImmutableList<>)) 
	            {
	                var converter = typeof(ImmutableListListConverter<>).MakeGenericType(targetType.GetGenericArguments());
	                return converter
	                    .GetMethod("ToImmutable", BindingFlags.Public | BindingFlags.Static)
	                    .Invoke(null, new []{obj});
	            }
	            return obj;
	        }
	
	        public object GetObjectToSerialize( object obj, Type targetType )
	        {
	            if ( targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(ImmutableList<>) )
	            {
	                var converter = typeof(ImmutableListListConverter<>).MakeGenericType(targetType.GetGenericArguments());
	                return converter
	                    .GetMethod("ToList", BindingFlags.Public | BindingFlags.Static)
	                    .Invoke(null, new []{obj});
	                
	            }
	            return obj;
	        }
	
	        public object GetCustomDataToExport( Type clrType, Type dataContractType )
	        {
	            throw new NotImplementedException();
	        }
	
	        public object GetCustomDataToExport( System.Reflection.MemberInfo memberInfo, Type dataContractType )
	        {
	            throw new NotImplementedException();
	        }
	
	
	        public void GetKnownCustomDataTypes( System.Collections.ObjectModel.Collection<Type> customDataTypes )
	        {
	            throw new NotImplementedException();
	        }
	
	
	        public Type GetReferencedTypeOnImport( string typeName, string typeNamespace, object customData )
	        {
	            throw new NotImplementedException();
	        }
	
	        public System.CodeDom.CodeTypeDeclaration ProcessImportedType( System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit )
	        {
	            throw new NotImplementedException();
	        }
	
	        public ImmutableSurrogateSerializer() { }
	    }
	}
	
	
