    using System;
    
    /// <summary>
    /// Creates a checksum as a ushort / UInt16.
    /// </summary>
    public class Crc16
    {
    	const ushort polynomial = 0xA001;
    	ushort[] table = new ushort[256];
    
    	/// <summary>
    	/// Initializes a new instance of the <see cref="Crc16"/> class.
    	/// </summary>
    	public Crc16()
    	{
    		ushort value;
    		ushort temp;
    		for (ushort i = 0; i < table.Length; ++i)
    		{
    			value = 0;
    			temp = i;
    			for (byte j = 0; j < 8; ++j)
    			{
    				if (((value ^ temp) & 0x0001) != 0)
    				{
    					value = (ushort)((value >> 1) ^ polynomial);
    				}
    				else
    				{
    					value >>= 1;
    				}
    				temp >>= 1;
    			}
    			table[i] = value;
    		}
    	}
    
    	/// <summary>
    	/// Computes the hash.
    	/// </summary>
    	/// <param name="input">The input.</param>
    	/// <returns></returns>
    	public static ushort ComputeHash(string input)
    	{
    		if(input == null)
    		{
    			input = "";
    		}
    
    		Crc16 crc = new Crc16();
    		byte[] bytes = Encoding.UTF8.GetBytes(input);
    		return crc.ComputeChecksum(bytes);
    	}
    
    	/// <summary>
    	/// Computes the checksum.
    	/// </summary>
    	/// <param name="bytes">The bytes.</param>
    	/// <returns>The checkum.</returns>
    	public ushort ComputeChecksum(byte[] bytes)
    	{
    		ushort crc = 0;
    		for (int i = 0; i < bytes.Length; ++i)
    		{
    			byte index = (byte)(crc ^ bytes[i]);
    			crc = (ushort)((crc >> 8) ^ table[index]);
    		}
    		return crc;
    	}
    
    	/// <summary>
    	/// Computes the checksum bytes.
    	/// </summary>
    	/// <param name="bytes">The bytes.</param>
    	/// <returns>The checksum.</returns>
    	public byte[] ComputeChecksumBytes(byte[] bytes)
    	{
    		ushort crc = ComputeChecksum(bytes);
    		return BitConverter.GetBytes(crc);
    	}
    }
