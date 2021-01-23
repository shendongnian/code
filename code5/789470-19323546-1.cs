			FileStream fs = null;
			try {
				fs = File.OpenRead(filePath);
				using (var br = new BinaryReader(fs)) {
					var by = new List<byte>();
					while (fs.Position < fs.Length) {
						by.Add(byte.Parse(Encoding.ASCII.GetString(br.ReadBytes(2)), NumberStyles.HexNumber));
					}
					var x = by.ToArray();
				}
			} finally {
				if (fs != null) {
					fs.Close();
					fs.Dispose();
				}
			}
