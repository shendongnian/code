    class TileBytes
    {
	public int Size;
	public TileBytes(int size)
	{
		Size = size;
	}
	
	public byte[] Generate(Tile tile)
	{
		byte[] buffer = new byte[Size * Size * 3];
		for (int u = 0; u < Size; u++)
		{
			for (int v = 0; v<Size; v++)
			{
				Color32 pixelColor = GetColor (tile, u, v);
				int bufferidx = 3 * (( u * Size) + v);
				buffer[bufferidx] = pixelColor.r;
				buffer[bufferidx + 1] = pixelColor.g;
				buffer[bufferidx + 2] = pixelColor.b;				
			}
		}
		return buffer;
	}
	public Color32 GetColor(Tile tile, int u, int v)
	{
		int h = v > Size / 2.0 ? 0 : 2;
		int w = u > Size / 2.0 ? 0 : 1;
		TileCorner tc = (TileCorner) h + w;
		return tile[tc].GetPixel(v,  Size - (u + 1));
	}
    }
