    public List<GameObject> imglist = new List<GameObject>();
    public List<Transform> imgPositions = new List<Transform>();
  
    void Start()
    {
        for(var i = 0 i < imglist.Count; ++i)
        {
            imglist[i].transform.position = imgPositions[i].position
        }
    }
