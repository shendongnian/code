	// Snippet of ErrorCode.
	enum ErrorCode
	{
		Success = 0x0000,
		MoreData = 0x00EA
	}
	[DllImport( Dll, CharSet = CharSet.Unicode )]
	public extern static int RegLoadMUIString(
		IntPtr registryKeyHandle, string value,
		StringBuilder outputBuffer, int outputBufferSize, out int requiredSize,
		RegistryLoadMuiStringOptions options, string path );
	/// <summary>
	///   Determines the behavior of <see cref="RegLoadMUIString" />.
	/// </summary>
	[Flags]
	internal enum RegistryLoadMuiStringOptions : uint
	{
		None = 0,
		/// <summary>
		///   The string is truncated to fit the available size of the output buffer. If this flag is specified, copiedDataSize must be NULL.
		/// </summary>
		Truncate = 1
	}
