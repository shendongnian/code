	using System;
	using System.Reflection;
	using log4net;
	using NHibernate.Type;
	/// <summary>
	/// This class serves as a helper class to properly en- and decode enum values to/from strings
	/// using hibernate. It is a generic class that can be used with any enumeration type and is designed
	/// to replace the standard NHibernate.EnumStringType entirely.
	/// 
	/// This class should be used whenever an enumeration is consisted via NHibernate, because it has a failsafe
	/// decoding of enumeration values from the database by defaulting them back to the given default value
	/// when an unknown enumeration value is found in the database, which the default NHibernate.EnumStrinType does not
	/// </summary>
	/// <typeparam name="T">The enumeration type to use</typeparam>
	public class EnumStringType<T> : EnumStringType where T : struct
	{
		private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private T _defaultValue;
		/// <summary>
		/// Create the type
		/// </summary>
		/// <param name="defaultValue_">Value to fallback to if an unknown enum value is found</param>
		public EnumStringType(T defaultValue_)
			: base(typeof(T))
		{
			_defaultValue = defaultValue_;
		}
		/// <summary>
		/// Get the value of the given code
		/// </summary>
		/// <param name="code_">The code will be decoded using Enum.TryParse with the Type of this EnumStringType instance</param>
		/// <returns>Either the defaultValue of this instance (logged with a warning) or the value of the code</returns>
		public override object GetInstance(object code_)
		{
			T instanceValue = _defaultValue;
			if (code_ != null && Enum.TryParse<T>(code_.ToString(), true, out instanceValue)) {
				_logger.Debug("Decoded [" + typeof(T) + "] enum value [" + instanceValue + "]");
			}
			else {
				_logger.Warn("Unknown [" + typeof(T) + "] enum value [" + code_ + "] found, defaulting to [" + instanceValue + "]");
			}
			return instanceValue;
		}
	}
