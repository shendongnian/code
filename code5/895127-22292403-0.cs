    [AsyncTimeout(200)]
    public async Task<ActionResult> DoAsync()
    {
        // Execute long running call.
        return View();
    }
