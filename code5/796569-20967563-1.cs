	/// <summary>
	/// The open scsi.
	/// </summary>
	/// <param name="scsiNumber">
	/// The scsi number.
	/// </param>
	/// <returns>
	/// The <see cref="SafeFileHandle"/>.
	/// </returns>
	/// <exception cref="Win32Exception">
	/// Will be thrown, when the safe file handle is not valid.
	/// </exception>
	private static SafeFileHandle OpenScsi(int scsiNumber)
	{
		var device = FileManagement.CreateFile(
			string.Format(@"\\.\Scsi{0}:", scsiNumber), 
			WinNT.GENERIC_READ | WinNT.GENERIC_WRITE, 
			FileShare.ReadWrite, 
			IntPtr.Zero, 
			FileMode.Open, 
			0, 
			IntPtr.Zero);
		if (device.IsInvalid)
		{
			throw new NativeException(string.Format(@"Error during the creation of a safe file handle for \\.\Scsi{0}:", scsiNumber));
		}
		return device;
	}
