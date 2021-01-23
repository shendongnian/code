    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MiscUtil.Conversion;
    
    public class Test
    {
    	public static void Main()
    	{
    		var message = Encoding.ASCII.GetBytes("message \"Render\"");
    
    			var lenc = new LittleEndianBitConverter();
    
    			var bytes = new List<byte[]>(new[]
    			{
    				lenc.GetBytes(message.LongLength),
    				message
    			});
    			    
    			var msg = new byte[bytes.Sum(barray => barray.LongLength)];
    			int offset = 0;
    			foreach (var bArray in bytes)
    			{
    				Buffer.BlockCopy(bArray, 0, msg, offset, bArray.Length);
    				offset = bArray.Length;
    			}
    
    			Console.WriteLine(BitConverter.ToString(msg).Replace("-", ":"));
    	}
    }
