	
	[DllImport("demo.dll", EntryPoint = "compute_similarity", CallingConvention =  CallingConvention.Cdecl)]
	static extern float compute_similarity(
		[Out, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VarEnum.VT_BSTR)] out string[] vertices
	);  
