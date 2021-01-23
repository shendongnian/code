    [HttpPost]
    public async Task<ActionResult> RequestReportGen()
    {
        await RunReport();
        return RedirectToAction("SuccessPage");
    }
