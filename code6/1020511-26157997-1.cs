	void loadMap(){
		bool isMap = false;
		string input = File.ReadAllText( Application.dataPath + 
		                                	"/Photon Unity Networking" +
												"/Resources/Maps/map0.txt" );
		string[] f = input.Split(new string[] {"\n", "\r", "\r\n"}, 
								 System.StringSplitOptions.RemoveEmptyEntries);
		if(f[0].Length > 0 && f[1].Length > 0)
		{
			int.TryParse(f[0], out mapHeight);
			int.TryParse(f[1], out mapWidth);
		}
		if (mapWidth > 0 && mapHeight > 0) {
						mapArray = new GameObject [mapHeight, mapWidth];
						int y = 0, x = 0;
						foreach (var row in input.Split('\n')) {
								x = 0;
								foreach (var col in row.Trim().Split(' ')) {
										if(int.Parse (col.Trim ()) < 8){
											mapArray [y, x] = Tiles [int.Parse (col.Trim ())];	
											mapTile = mapArray [y, x];
											GameObject.Instantiate (mapTile, new Vector3 (x, mapHeight-y, 0),
					                       							Quaternion.Euler (0, 0, 0));
											x++;
											isMap = true;
										}else{ isMap = false; }
								}
								if(isMap == true){ y++; }
						}
		}
	}
