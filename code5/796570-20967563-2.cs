	/// <summary>
	/// The get serial number using miniport driver.
	/// </summary>
	/// <param name="busNumber">
	/// The bus number.
	/// </param>
	/// <param name="deviceNumber">
	/// The device number.
	/// </param>
	/// <returns>
	/// The <see cref="string"/>.
	/// </returns>
	/// <exception cref="NativeException">
	/// Throws an excpetion, if the device io control couldn't execute successfully!
	/// </exception>
	internal static string GetSerialNumberUsingMiniportDriver(int busNumber, byte deviceNumber = 0)
	{
		using (var device = OpenScsi(busNumber))
		{
			var bytesReturned = default(uint);
			var sic = new SCSI.SRB_IO_CONTROL();
			var sop = new Disk.SENDCMDOUTPARAMS();
			var sip = new Disk.SENDCMDINPARAMS();
			var id = new ATA.IDENTIFY_DEVICE_DATA();
			var buffer = new byte[Marshal.SizeOf(sic) + Marshal.SizeOf(sop) + Marshal.SizeOf(id)];
			sic.HeaderLength = (uint)Marshal.SizeOf(sic);
			sic.Timeout = 10000;
			sic.Length = (uint)(Marshal.SizeOf(sop) + Marshal.SizeOf(id));
			sic.ControlCode = SCSI.IOCTL_SCSI_MINIPORT_IDENTIFY;
			// disk access signature
			sic.Signature = Encoding.ASCII.GetBytes("SCSIDISK".ToCharArray());
			var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(sic));
			Marshal.StructureToPtr(sic, ptr, true);
			Marshal.Copy(ptr, buffer, 0, Marshal.SizeOf(sic));
			sip.irDriveRegs.bCommandReg = (byte)ATA.CTRL_CMDS.ATA_IDENTIFY;
			sip.bDriveNumber = deviceNumber;
			ptr = Marshal.AllocHGlobal(Marshal.SizeOf(sip));
			Marshal.StructureToPtr(sip, ptr, true);
			Marshal.Copy(ptr, buffer, Marshal.SizeOf(sic), Marshal.SizeOf(sip));
			if (
				!FileManagement.DeviceIoControl(
					device, 
					SCSI.IOCTL_SCSI_MINIPORT, 
					buffer, 
					(uint)(Marshal.SizeOf(sic) + Marshal.SizeOf(sip) - 1), 
					buffer, 
					(uint)(Marshal.SizeOf(sic) + Marshal.SizeOf(sop) + Marshal.SizeOf(id)), 
					ref bytesReturned, 
					IntPtr.Zero))
			{
				throw new NativeException("P/invoke error on SCSI MINIPORT IDENTIFY");
			}
			var resultPtr = Marshal.AllocHGlobal(Marshal.SizeOf(id));
			Marshal.Copy(buffer, Marshal.SizeOf(sic) + Marshal.SizeOf(sop), resultPtr, Marshal.SizeOf(id));
			id = (ATA.IDENTIFY_DEVICE_DATA)Marshal.PtrToStructure(resultPtr, typeof(ATA.IDENTIFY_DEVICE_DATA));
			var model = Encoding.ASCII.GetString(id.ModelNumber).Replace('\0', ' ').Trim();
			if (!string.IsNullOrEmpty(model))
			{
				model = model.Swap();
				Logging.Add(
					Message.Type.INFO, 
					string.Format("Found model definition (via IOCTL_SCSI_MINIPORT) for storage device #{0}/{1}: {2}", busNumber, deviceNumber, model));
			}
			var serial = Encoding.ASCII.GetString(id.SerialNumber).Replace('\0', ' ').Trim();
			if (!string.IsNullOrEmpty(serial))
			{
				serial = serial.Swap();
				Logging.Add(
					Message.Type.INFO, 
					string.Format("Found serial number (via IOCTL_SCSI_MINIPORT) for storage device #{0}/{1}: {2}", busNumber, deviceNumber, serial));
			}
			else
			{
				Logging.Add(
					Message.Type.INFO, 
					string.Format("Couldn't find serial number (via IOCTL_SCSI_MINIPORT) for storage device #{0}/{1}", busNumber, deviceNumber));
			}
			return serial.Trim();
		}
	}
