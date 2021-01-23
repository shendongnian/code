    GameObject[,] tiles = new GameObject[s,s];
    public GameObject[] arrayOfTilesTypes; // Simply populate this in inspector with blocking and non blocking gameObjects
    
    for(int i = 0; i<s;  i++) {
        for(int j = 0; j<s;  j++) {
            int objtype = Random.Range(0,arrayOfTilesType.Length);
            tiles[i,j] = Instanciate(arrayOfTilesTypes[objtype],new Vector3(i,0,j),Quaternion.Identity) as GameObject;
        }
    }
