		public static CfbFileFormat GetCfbFileFormat(Stream fileData)
		{
			if (!fileData.CanSeek)
				throw new ArgumentException("Data stream must be seekable.", nameof(fileData));
			try
			{
				// Notice that values in a CFB files are always little-endian. Fortunately BinaryReader.ReadUInt16/ReadUInt32 reads with little-endian.
				using (BinaryReader reader = new BinaryReader(fileData))
				{
					// Check that data has the CFB file header
					var header = reader.ReadBytes(8);
					if (!header.SequenceEqual(new byte[] {0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1}))
						return CfbFileFormat.Unknown;
					// Get sector size (2 byte uint) at offset 30 in the header
					// Value at 1C specifies this as the power of two. The only valid values are 9 or 12, which gives 512 or 4096 byte sector size.
					fileData.Position = 30;
					ushort readUInt16 = reader.ReadUInt16();
					int sectorSize = 1 << readUInt16;
					// Get first directory sector index at offset 48 in the header
					fileData.Position = 48;
					var rootDirectoryIndex = reader.ReadUInt32();
					// File header is one sector wide. After that we can address the sector directly using the sector index
					var rootDirectoryAddress = sectorSize + (rootDirectoryIndex * sectorSize);
					// Object type field is offset 80 bytes into the directory sector. It is a 128 bit GUID, encoded as "DWORD, WORD, WORD, BYTE[8]".
					fileData.Position = rootDirectoryAddress + 80;
					var bits127_96 = reader.ReadInt32();
					var bits95_80 = reader.ReadInt16();
					var bits79_64 = reader.ReadInt16();
					var bits63_0 = reader.ReadBytes(8);
					var guid = new Guid(bits127_96, bits95_80, bits79_64, bits63_0);
					// Compare to known file format GUIDs
					CfbFileFormat result;
					return Formats.TryGetValue(guid, out result) ? result : CfbFileFormat.Unknown;
				}
			}
			catch (IOException)
			{
				return CfbFileFormat.Unknown;
			}
			catch (OverflowException)
			{
				return CfbFileFormat.Unknown;
			}
		}
		public enum CfbFileFormat
		{
			Doc,
			Xls,
			Msi,
			Ppt,
			Unknown
		}
		private static readonly Dictionary<Guid, CfbFileFormat> Formats = new Dictionary<Guid, CfbFileFormat>
		{
			{Guid.Parse("{00020810-0000-0000-c000-000000000046}"), CfbFileFormat.Xls},
			{Guid.Parse("{00020820-0000-0000-c000-000000000046}"), CfbFileFormat.Xls},
			{Guid.Parse("{00020906-0000-0000-c000-000000000046}"), CfbFileFormat.Doc},
			{Guid.Parse("{000c1084-0000-0000-c000-000000000046}"), CfbFileFormat.Msi},
			{Guid.Parse("{64818d10-4f9b-11cf-86ea-00aa00b929e8}"), CfbFileFormat.Ppt}
		};
