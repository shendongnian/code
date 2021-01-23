    public async Task<ActionResult> SomeActionWithLongRunningProcess()
    {
        await LongRunningProcess();
        return View();
    }
