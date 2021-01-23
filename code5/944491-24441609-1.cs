	using namespace System;
	public ref class EnumHelper 
	{
	public:
		generic <typename T> where T : Enum
		static T Parse(String^ value)
		{
			return Parse<T>(value,
							false);
		}
		 
		generic <typename T> where T : Enum
		static T Parse(String^ value,
					   bool ignoreCase)
		{
			return safe_cast<T>(Enum::Parse(T::typeid,
											value,
											ignoreCase));
		}
	};
