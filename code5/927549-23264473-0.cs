    FileStream stream = new FileStream(save_log.FileName, FileMode.Create, FileAccess.ReadWrite);
    foreach( byte b in Hex_to_Byte(hexString) )
        stream.WriteByte(b);
    stream.Close();
		static internal IEnumerable<byte>Hex_to_Byte(string s)
		{
			bool haveFirstByte = false;
			int firstByteValue = 0;
			foreach( char c in s)
			{
				if( char.IsWhiteSpace(c))
					continue;
				if( !haveFirstByte)
				{
					haveFirstByte = true;
					firstByteValue = GetHexValue(c) << 4;
				}
				else
				{
					haveFirstByte = false;
					yield return unchecked((byte)(firstByteValue + GetHexValue(c)));
				}
				
			}
		}
		static string hexChars = "0123456789ABCDEF";
		static int GetHexValue(char c)
		{
			int v = hexChars.IndexOf(char.ToUpper(c));
			if (v < 0)
				throw new ArgumentOutOfRangeException("c", string.Format("not a hex char: {0}"));
			return v;
		}
