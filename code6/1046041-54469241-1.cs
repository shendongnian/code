		private struct TypedReferenceAccess
		{
			public IntPtr Value;
			public IntPtr Type;
		}
		private static unsafe Type GetTypeFromTypeHandle(IntPtr handle)
		{
			TypedReferenceAccess tr = new TypedReferenceAccess()
			{
				Type = handle
			};
			return __reftype(*(TypedReference*)&tr);
		}
