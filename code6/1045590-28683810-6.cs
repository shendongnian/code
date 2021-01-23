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
		// Fade OUT wall section  (Needs DOTween (free) installed)
		collider.gameObject.renderer.renderer.material.DOFade(0.65f, 0.2f);
    }
    void WallRay_OnExit(Collider collider) {
		// Fade IN wall section  (Needs DOTween (free) installed)
		collider.gameObject.renderer.renderer.material.DOFade(1f, 0.2f);
    }
