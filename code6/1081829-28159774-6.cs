	using (var fs = new FileStream("yourfile.bin", FileMode.Open))
	{
		using (var br = new BinaryReader(fs))
		{
			int sections = br.ReadInt32();
			for (int i = 0; i < sections; i++)
			{
				int sectionLength = br.ReadInt32();
				byte[] sectionData = br.ReadBytes(sectionLength);
				// Use the data however you want ...
				// A good idea would be to check whether it's text or an image
			}
		}
	}
