	public static unsafe object BoxNullable<T>(T? nullable) where T : struct
	{
		object scam = new NullableFake<T>(nullable);
		TypedReference tr = __makeref(scam);
		IntPtr typehandle = typeof(Nullable<T>).TypeHandle.Value;
		IntPtr* trstruct = (IntPtr*)&tr;
		**((IntPtr**)trstruct[0]) = typehandle;
		return scam;
	}
	
	struct NullableFake<T> where T : struct
	{
		public readonly bool hasValue;
		private readonly T value;
		
		public NullableFake(T? nullable) : this()
		{
			if(nullable.HasValue)
			{
				hasValue = true;
				value = nullable.Value;
			}
		}
	}
