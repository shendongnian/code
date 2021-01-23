	var str = "0123456789ABCDEF";
	var ms = new MemoryStream(Encoding.ASCII.GetBytes(str));
	var br = new BinaryReader(ms);
	var by = new List<byte>();
	while (ms.Position < ms.Length) {
		by.Add(byte.Parse(Encoding.ASCII.GetString(br.ReadBytes(2)), NumberStyles.HexNumber));
	}
	return by;
