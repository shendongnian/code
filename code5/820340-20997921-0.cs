    int[,] tiles = new int[s,s];
    public GameObject[] arrayOfTilesTypes; // Simply populate this in inspector with blocking and non blocking gameObjects
    
    for(int i = 0; i<s;  i++) {
        for(int j = 0; j<s;  j++) {
            tiles[i,j] = Random.Range(0,arrayOfTilesType.Length);
            GameObject tile = Instanciate(arrayOfTilesTypes[tiles[i,j]],new Vector3(i,0,j),Quaternion.Identity) as GameObject;
        }
    }
