	private void _buildGeometryBuffers()
	{
		System.IO.FileStream fs = new System.IO.FileStream(@"Chapter6/Content/skull.txt", System.IO.FileMode.Open);
		int vcount = 0;
		int tcount = 0;
		//string ignore = string.Empty; // this is not needed for my C# version
		using (System.IO.StreamReader reader = new System.IO.StreamReader(fs))
		{
			// Get the vertice count
			string currentLine = reader.ReadLine();
			string extractedLine = currentLine.Substring(currentLine.IndexOf(" ") + 1);
			vcount = int.Parse(extractedLine);
			// Get the indice count
			currentLine = reader.ReadLine();
			extractedLine = currentLine.Substring(currentLine.IndexOf(" ") + 1);
			tcount = int.Parse(extractedLine);
			// Create vertex buffer
			// Skip over the first 2 lines (these are not the lines we are looking for)
			currentLine = reader.ReadLine();
			currentLine = reader.ReadLine();
			string[] positions = new string[6];
			List<VertexPosCol> vertices = new List<VertexPosCol>(vcount);
			for (int i = 0; i < vcount; ++i)
			{
				currentLine = reader.ReadLine();
				extractedLine = currentLine.Substring(currentLine.IndexOf("\t") + 1);
				positions = extractedLine.Split(' ');
				// We only use the first 3, the last 3 are normals which are not used.
				vertices.Add(new VertexPosCol(
					new Vector3(float.Parse(positions[0]), float.Parse(positions[1]), float.Parse(positions[2])),
					Color.Black)
				);
			}
			BufferDescription vbd = new BufferDescription();
			vbd.Usage = ResourceUsage.Immutable;
			vbd.SizeInBytes = Utilities.SizeOf<VertexPosCol>() * vcount;
			vbd.BindFlags = BindFlags.VertexBuffer;
			vbd.StructureByteStride = 0;
			_vBuffer = Buffer.Create(d3dDevice, vertices.ToArray(), vbd);
			// Create the index buffer
			// Skip over the next 3 lines (these are not the lines we are looking for)
			currentLine = reader.ReadLine();
			currentLine = reader.ReadLine();
			currentLine = reader.ReadLine();
			string[] indexes = new string[6];
			_meshIndexCount = 3 * tcount;
			List<int> indices = new List<int>(_meshIndexCount);
			for (int i = 0; i < tcount; ++i)
			{
				currentLine = reader.ReadLine();
				extractedLine = currentLine.Substring(currentLine.IndexOf("\t") + 1);
				indexes = extractedLine.Split(' ');
				indices.Add(int.Parse(indexes[0]));
				indices.Add(int.Parse(indexes[1]));
				indices.Add(int.Parse(indexes[2]));
			}
			BufferDescription ibd = new BufferDescription();
			ibd.Usage = ResourceUsage.Immutable;
			ibd.SizeInBytes = Utilities.SizeOf<int>() * _meshIndexCount;
			ibd.BindFlags = BindFlags.IndexBuffer;
			_iBuffer = Buffer.Create(d3dDevice, indices.ToArray(), ibd);
		}
		fs.Close();
	}
