    public int GetInteger(int memoryAddress, uint bytes) {
		int bytesRead;
		byte[] memoryValue;
		if(bytes == 1) {
			#region single byte
			byte[] temp = pReader.ReadProcessMemory((IntPtr)memoryAddress, bytes, out bytesRead);
			memoryValue = new byte[4];
			memoryValue[0] = temp[0];
			memoryValue[1] = memoryValue[2] = memoryValue[3] = 0;
			// little endian
			#endregion
		} else if(bytes == 2) {
			#region two bytes
			byte[] temp = pReader.ReadProcessMemory((IntPtr)memoryAddress, bytes, out bytesRead);
			memoryValue = new byte[4];
			memoryValue[0] = temp[0];
			memoryValue[1] = temp[1];
			memoryValue[2] = memoryValue[3] = 0;
			#endregion
		} else if(bytes == 3) {
			#region three bytes
			byte[] temp = pReader.ReadProcessMemory((IntPtr)memoryAddress, bytes, out bytesRead);
			memoryValue = new byte[4];
			memoryValue[0] = temp[0];
			memoryValue[1] = temp[1];
			memoryValue[2] = temp[2];
			memoryValue[3] = 0;
			#endregion
		} else if(bytes == 4) {
			memoryValue = pReader.ReadProcessMemory((IntPtr)memoryAddress, bytes, out bytesRead);
		} else {
			// do more if you have to deal with values like eight-byte values.
		}
		int result = BitConverter.ToInt32(memoryValue, 0);
		if(result < 0) {
			throw new OverflowException(result + "(possible overflow)");
		}
		return result;
	}
	public string GetString(int memoryAddress, uint bytes) {
		int bytesRead;
		byte[] memoryValue = pReader.ReadProcessMemory((IntPtr)memoryAddress, bytes, out bytesRead);
		Encoding encoding = Encoding.Default;
		string result = encoding.GetString(memoryValue, 0, (int)bytes);
		result = result.TrimEnd('\0');
		return result;
	}
	public void SetInteger(int memoryAddress, int value, uint bytes) {
		byte[] temp = new byte[bytes];
		for(int i = 0; i < bytes; i++) {
			temp[i] = 0;
		}
		byte[] byteValue = BitConverter.GetBytes(value);
		pReader.WriteProcessMemory((IntPtr)memoryAddress, byteValue, bytes);
	}
	public void SetString(int memoryAddress, string value, uint bytes) {
		byte[] byteValue = new byte[bytes];
		for(int i = 0; i < bytes; i++) {
			byteValue[i] = 0;
		}
		Encoding encoding = Encoding.Default;
		byteValue = encoding.GetBytes(value);
		pReader.WriteProcessMemory((IntPtr)memoryAddress, byteValue, bytes);
	}
