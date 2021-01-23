    var fileName = @"c:\temp\StructureMap.pdb";
	using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
	{
		using (BinaryReader binReader = new BinaryReader(fs))
		{
			// This is where the GUID for the .pdb file is stored
			fs.Position = 0x00000a0c;
			//starts at 0xa0c but is pieced together up to 0xa1b
			byte[] guidBytes = binReader.ReadBytes(16);
			Guid pdbGuid = new Guid(guidBytes);
			Debug.WriteLine(pdbGuid.ToString());
		}
	}
