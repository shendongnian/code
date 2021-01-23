	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using System.Linq.Expressions;
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
	
	        public static object ToImmutable( object list )
	        {
	            return ToImmutable(( List<T> ) list);
	        }
	
	        public static object ToList(object list){
	            return ToList(( ImmutableList<T> ) list);
	        }
	
	    }
	
	    static class ImmutableListListConverter {
	
	
	        static ConcurrentDictionary<Tuple<string, Type>, Func<object,object>> _MethodCache 
	            = new ConcurrentDictionary<Tuple<string, Type>, Func<object,object>>();
	
	        public static Func<object,object> CreateMethod( string name, Type genericType )
	        {
	            var key = Tuple.Create(name, genericType);
	            if ( !_MethodCache.ContainsKey(key) )
	            {
	                _MethodCache[key] = typeof(ImmutableListListConverter<>)
	                    .MakeGenericType(new []{genericType})
	                    .GetMethod(name, new []{typeof(object)})
	                    .MakeLambda();
	            }
	            return _MethodCache[key];
	        }
	        public static Func<object,object> ToImmutableMethod( Type targetType )
	        {
	            return ImmutableListListConverter.CreateMethod("ToImmutable", targetType.GenericTypeArguments[0]);
	        }
	
	        public static Func<object,object> ToListMethod( Type targetType )
	        {
	            return ImmutableListListConverter.CreateMethod("ToList", targetType.GenericTypeArguments[0]);
	        }
	
	        private static Func<object,object> MakeLambda(this MethodInfo method )
	        {
	            return (Func<object,object>) method.CreateDelegate(Expression.GetDelegateType(
	            (from parameter in method.GetParameters() select parameter.ParameterType)
	            .Concat(new[] { method.ReturnType })
	            .ToArray()));
	        }
	
	    }
	
	    public class ImmutableSurrogateSerializer : IDataContractSurrogate
	    {
	        static ConcurrentDictionary<Type, Type> _TypeCache = new ConcurrentDictionary<Type, Type>();
	
	        public Type GetDataContractType( Type targetType )
	        {
	            if ( _TypeCache.ContainsKey(targetType) )
	            {
	                return _TypeCache[targetType];
	            }
	
	            if(targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(ImmutableList<>)) 
	            {
	                return _TypeCache[targetType] 
	                    = typeof(List<>).MakeGenericType(targetType.GetGenericArguments());
	            }
	            else
	            {
	                return targetType;
	            }
	        }
	
	        public object GetDeserializedObject( object obj, Type targetType )
	        {
	            if ( _TypeCache.ContainsKey(targetType) )
	            {
	               return ImmutableListListConverter.ToImmutableMethod(targetType)(obj);
	            }
	            return obj;
	        }
	
	        public object GetObjectToSerialize( object obj, Type targetType )
	        {
	            if ( targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(ImmutableList<>) )
	            {
	               return ImmutableListListConverter.ToListMethod(targetType)(obj);
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
	
