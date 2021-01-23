    public async Task<ActionResult> IndexAsync()
    {
        try
        {
            return View();
        }
        finally
        {
            await task;
        }
    }
