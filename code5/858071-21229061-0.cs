    // Set to whatever ending marker is used in your scenario.
	var endingMarker = new byte[] { 0x01, 0x02, 0x03 };
	var buffer = new List<byte>();
	// Continue to read until ending marker is read.
	while (!endingMarker.SequenceEqual(buffer.Skip(Math.Max(0, buffer.Count - endingMarker.Length))))
	{
		// Read one byte to the buffer.
		buffer.Add(sp.ReadByte());
	}
	// Remove ending marker.
	var result = buffer.Take(buffer.Count - endingMarker.Length).ToArray();
