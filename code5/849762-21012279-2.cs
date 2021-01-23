	// Calculate new position
	long newPos = audioFileReader.Position + (long)(audioFileReader.WaveFormat.AverageBytesPerSecond * 2.5);
	// Force it to align to a block boundary
	if ((newPos % audioFileReader.WaveFormat.BlockAlign) != 0)
		newPos -= newPos % audioFileReader.WaveFormat.BlockAlign;
	// Force new position into valid range
	newPos = Math.Max(0, Math.Min(audioFileReader.Length, newPos));
	// set position
	audioFileReader.Position = newPos;
