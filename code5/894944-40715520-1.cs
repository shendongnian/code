    /// <summary>
	/// Convert an object to a specific type with a support of string parsing if needed
	/// </summary>
	/// <param name="input">Object to convert</param>
	/// <param name="type">Type of converted object</param>
	/// <returns>Object converted</returns>
	public static object ConvertTo(this object input, Type type)
	{
		object returnValue;
		try
		{
			// Try change type
			returnValue = System.Convert.ChangeType(input, type);
		}
		catch(Exception exception)
		{
			if(exception is InvalidCastException || exception is FormatException)
			{
				// Try to parse because the cast is invalid
				// If the type is an enumeration
				if(type.IsEnum)
				{
					// Try to parse the string
					try { returnValue = Enum.Parse(type, input.ToString(), true); }
					catch(Exception) { returnValue = System.Convert.ChangeType(input, typeof(int)); }
				}
				else if(type.IsNullable())
				{
					// If the type is a nullable type (int?,long?,double?....)
					returnValue = input == null ? null : System.Convert.ChangeType(input, Nullable.GetUnderlyingType(type));
				}
				else if(input is string || input == null)
				{
					// If the original type is string, we try to parse : if parsing failed then return value is the default value of the type
					if(!((string)input).TryParse(type, out returnValue))
					{
						// Conversion "1" to true is not supported by previous case, so if return type is boolean try to convert "1" to true
						if(type == typeof(Boolean))
							returnValue = ((string)input).ToBoolean();
					}
				}
				else
					throw new InvalidCastException(String.Format("Unable to cast \"{0}\" in {1}", input, type.Name));
			}
			else
				throw;
		}
		// return the value converted
		return returnValue;
	}
	/// <summary>
	/// Try to parse a string
	/// </summary>
	/// <param name="text">Text to parse</param>
	/// <param name="type">Type of result</param>
	/// <param name="result">Result</param>
	/// <returns>True if string was parsed, else false</returns>
	public static bool TryParse(this string text, Type type, out object result)
	{
		// Get specific converter for the type
		TypeConverter converter = TypeDescriptor.GetConverter(type);
		// If there is a converter and conversion is valid
		if(converter != null && converter.IsValid(text))
		{
			// Convert
			result = converter.ConvertFromInvariantString(text);
			return true;
		}
		else
		{
			// Return the default value of the type
			result = type.GetDefaultValue();
			return false;
		}
	}
	/// <summary>
	/// Get the default value of a type
	/// </summary>
	/// <param name="type">Type</param>
	/// <returns>Default value</returns>
	public static object GetDefaultValue(this Type type)
	{
		return type.IsValueType ? Activator.CreateInstance(type) : null;
	}
	/// <summary>
	/// Define if a type is a nullable type (int?, long?, double?...)
	/// </summary>
	/// <param name="type">Type</param>
	/// <returns>true if the type is a nullable type</returns>
	public static bool IsNullable(this Type type)
	{
		return (!type.IsGenericType) ? false : type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
	}
