    private RayCaster wallRay;
    void Start() {
        wallRay = new RayCaster();
        wallRay.OnRayEnter += WallRay_OnEnter;
        wallRay.OnRayExit += WallRay_OnExit;
        wallRay.LayerMask = RayCaster.GetLayerMask("Wall");
        wallRay.StartTransform = cam.transform;
        wallRay.EndTransform = PlayerManager.Player.transform;
    }
    void Update() {
        wallRay.CastLine();
    }
    void WallRay_OnEnter(Collider collider) {
        Debug.Log("Wall Obstructed: [" + collider.gameObject.name + "]");
    }
    void WallRay_OnExit(Collider collider) {
        Debug.Log("Wall Visible Again: [" + collider.gameObject.name + "]");
    }
