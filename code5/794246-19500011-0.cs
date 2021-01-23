	public class PHPTranscoder : ITranscoder
	{
		...
		public static uint TypeCodeToFlag(TypeCode code)
		{
			switch (code)
			{
				case TypeCode.String: return 0;
				case TypeCode.Int16: return 1;
				case TypeCode.Int32: return 1;
				case TypeCode.Int64: return 1;
				case TypeCode.UInt16: return 1;
				case TypeCode.UInt32: return 1;
				case TypeCode.UInt64: return 1;
				case TypeCode.Decimal: return 2;
				case TypeCode.Boolean: return 3;
				default: return 0; //default to string
			}
			// THE FOLLOWING IS COUCHBASE'S ORGINAL CODE
			// return (uint)((int)code | 0x0100);
		}
		...
	}
