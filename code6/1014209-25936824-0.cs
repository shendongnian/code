    void Start() {
        if(Network.isClient) {
            networkView.RPC("SpawnBall", RPCMode.AllBuffered)
        }
    }
    [RPC]
    void SpawnBall(NetworkViewID viewID, Vector3 location) {
        GameObject objPrefab = Resources.Load("Ball") as GameObject;
        GameObject obj = Instantiate(objPrefab) as GameObject;
    }
