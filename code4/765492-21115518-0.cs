    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MyStruct
    {
    	const int ARRAY_SIZE = 100;
    
    	public byte StartOfText;
    	public byte DisableChecksum;
    	public byte ProtocolVersion;
    	public byte Code;
    	public Int16 Size;
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = ARRAY_SIZE)]
    	public byte[] Data;
    	public byte EndOfText;
    
    	public MyStruct(CommandCode commandCode, string commandData)
    	{
    		this.StartOfText = 0x02;
    		this.DisableChecksum = 0x00;
    		this.ProtocolVersion = 0x35;
    		this.Code = (byte)commandCode;
    		this.Size = (Int16)commandData.Length;
    		this.Data = new byte[ARRAY_SIZE];
    		byte[] bytes = Encoding.ASCII.GetBytes(commandData);
    		Array.Copy(bytes, Data, bytes.Length);
    		//this.Data = Encoding.ASCII.GetBytes(commandData);
    		this.EndOfText = 0x03;
    	}
    
    	public byte[] ToByteArray()
    	{
    		byte[] arr = null;
    		IntPtr ptr = IntPtr.Zero;
    		try
    		{
    			int size = Marshal.SizeOf(this);
    			arr = new byte[size];
    			ptr = Marshal.AllocHGlobal(size);
    			Marshal.StructureToPtr(this, ptr, true);
    			Marshal.Copy(ptr, arr, 0, size);
    		}
    		catch (Exception e)
    		{
    			MessageBox.Show(e.Message);
    		}
    		finally
    		{
    			Marshal.FreeHGlobal(ptr);
    		}
    
    		return arr;
    	}
    }
