	[TypeConverter(typeof(EnumConverter))]
	static public class EnumSerializationHelper {
		static public T FromString<T>(string value) {
			return (T)Enum.Parse(typeof(T), value, true);
		}
	}
