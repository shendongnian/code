    ProcessMemoryReader memoryReader = new ProcessMemoryReader();
    memoryReader.ReadProcess = process;
    memoryReader.OpenProcess();
...
    public string GetString(int memoryAddress, uint bytes) {
    	int bytesRead;
    	byte[] memoryValue = memoryReader.ReadProcessMemory((IntPtr)memoryAddress, bytes, out bytesRead);
    	Encoding encoding = Encoding.Default;
    	string result = encoding.GetString(memoryValue, 0, (int)bytes);
    	result = result.TrimEnd('\0');
    	return result;
    }
