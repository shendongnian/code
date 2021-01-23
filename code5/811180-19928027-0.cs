Adolfo suggested changing the type of the problematic property from string to object in the hope that it would fool the XAML serialization process into using my custom TypeConverter or ValueSerializer implementations. In fact, this approach did not work, but it led me to experiment with using a new custom type to store the binary string data.
Since the CLR string type is sealed, it is not possible to sub-class it, but a similar result can be achieved by creating a custom type that encapsulates a string value and the logic necessary to convert it to/from Base64, as well as implicit conversion to/from string which enables it to be used as a plug-in replacement for the CLR string type. Here's my implementation of this custom type:
	/// <summary>
	/// Implements a string type that supports XAML serialization of non-printable characters via an associated type converter that converts to Base64 format. 
	/// </summary>
	[TypeConverter(typeof(BinaryStringConverter))]
	public class BinaryString
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BinaryString"/> class and populates it with the passed string value.
		/// </summary>
		/// <param name="value">A <see cref="string"/> that represents the value with which to populate this instance.</param>
		public BinaryString(string value)
		{
			Value = value;
		}
		/// <summary>
		/// Gets the raw value of this instance.
		/// </summary>
		public string Value { get; private set; }
		/// <summary>
		/// Implements an implicit conversion from <see cref="string"/>.
		/// </summary>
		/// <param name="value">A <see cref="string"/> that represents the value to convert.</param>
		/// <returns>A new <see cref="BinaryString"/> that represents the converted value.</returns>
		public static implicit operator BinaryString(string value)
		{
			return new BinaryString(value);
		}		
		/// <summary>
		/// Implements an implicit conversion to <see cref="string"/>.
		/// </summary>
		/// <param name="value">A <see cref="BinaryString"/> that represents the value to convert.</param>
		/// <returns>The <see cref="string"/> content of the passed value.</returns>
		public static implicit operator string(BinaryString value)
		{
			return value.Value;
		}
		/// <summary>
		/// Returns the value of this instance in <c>Base64</c> format.
		/// </summary>
		/// <returns>A <see cref="string"/> that represents the <c>Base64</c> value of this instance.</returns>
		public string ToBase64String()
		{
			return Value == null ? null : Convert.ToBase64String(Encoding.UTF8.GetBytes(Value));
		}
		/// <summary>
		/// Creates a new instance from the passed <c>Base64</c> string.
		/// </summary>
		/// <param name="value">A <see cref="string"/> that represent a <c>Base64</c> value to convert from.</param>
		/// <returns>A new <see cref="BinaryString"/> instance.</returns>
		public static BinaryString CreateFromBase64String(string value)
		{
			return new BinaryString(value == null ? null : Encoding.UTF8.GetString(Convert.FromBase64String(value)));
		}
	}
