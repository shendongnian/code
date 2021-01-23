    public async Task<ActionResult> GizmosAsync()
    {
        var gizmoService = new GizmoService();
        var result = await gizmoService.GetGizmosAsync();
        return View("Gizmos", result);
    }
