	using System;
	namespace Newtonsoft.Json.Linq
	{
		public static class SafeJsonConvertExtensions
		{
			public static object ToObjectCollectionSafe(this JToken jToken, Type objectType)
			{
				return ToObjectCollectionSafe(jToken, objectType, JsonSerializer.CreateDefault());
			}
			public static object ToObjectCollectionSafe(this JToken jToken, Type objectType, JsonSerializer jsonSerializer)
			{
				var expectArray = typeof(System.Collections.IEnumerable).IsAssignableFrom(objectType);
				if (jToken is JArray jArray)
				{
					if (!expectArray)
					{
						//to object via singel
						if (jArray.Count == 0)
							return JValue.CreateNull().ToObject(objectType, jsonSerializer);
						if (jArray.Count == 1)
							return jArray.First.ToObject(objectType, jsonSerializer);
					}
				}
				else if (expectArray)
				{
					//to object via JArray
					return new JArray(jToken).ToObject(objectType, jsonSerializer);
				}
				return jToken.ToObject(objectType, jsonSerializer);
			}
			public static T ToObjectCollectionSafe<T>(this JToken jToken)
			{
				return (T)ToObjectCollectionSafe(jToken, typeof(T));
			}
			public static T ToObjectCollectionSafe<T>(this JToken jToken, JsonSerializer jsonSerializer)
			{
				return (T)ToObjectCollectionSafe(jToken, typeof(T), jsonSerializer);
			}
		}
	}
