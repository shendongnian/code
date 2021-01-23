	public ActionResult Gizmos()
	{
		ViewBag.SyncOrAsync = "Synchronous";
		var gizmoService = new GizmoService();
		return View("Gizmos", gizmoService.GetGizmos());
	}
	public async Task<ActionResult> GizmosAsync()
	{
		ViewBag.SyncOrAsync = "Asynchronous";
		var gizmoService = new GizmoService();
		return View("Gizmos", await gizmoService.GetGizmosAsync());
	}
