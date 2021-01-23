	/// <summary>
	/// The SRB_IO_CONTROL.
	/// Define header for I/O control SRB.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	internal struct SRB_IO_CONTROL
	{
		/// <summary>
		/// The HeaderLength.
		/// </summary>
		public uint HeaderLength;
		/// <summary>
		/// The Signature.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public byte[] Signature;
		/// <summary>
		/// The Timeout.
		/// </summary>
		public uint Timeout;
		/// <summary>
		/// The ControlCode.
		/// </summary>
		public uint ControlCode;
		/// <summary>
		/// The ReturnCode.
		/// </summary>
		public uint ReturnCode;
		/// <summary>
		/// The Length.
		/// </summary>
		public uint Length;
	}
