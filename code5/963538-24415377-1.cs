    /// <summary>
    /// Tile prefab to fill background.
    /// </summary>
    [SerializeField]
    public GameObject tilePrefab;
    
    /// <summary>
    /// Use this for initialization 
    /// </summary>
    void Start()
    {
        if (tilePrefab.renderer == null)
        {
            Debug.LogError("There is no renderer available to fill background.");
        }
    
        // tile size.
        Vector2 tileSize = tilePrefab.renderer.bounds.size;
    
        // set camera to orthographic.
        Camera mainCamera = Camera.main;
        mainCamera.orthographic = true;
    
        // columns and rows.
        int columns = Mathf.CeilToInt(mainCamera.aspect * mainCamera.orthographicSize / tileSize.x);
        int rows = Mathf.CeilToInt(mainCamera.orthographicSize / tileSize.y);
    
        // from screen left side to screen right side, because camera is orthographic.
        for (int c = -columns; c < columns; c++)
        {
            for (int r = -rows; r < rows; r++)
            {
                Vector2 position = new Vector2(c * tileSize.x + tileSize.x / 2, r * tileSize.y + tileSize.y / 2);
    
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity) as GameObject;
                tile.transform.parent = transform;
            }
        }
    }
