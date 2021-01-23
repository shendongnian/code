    [HttpPost, ActionName ("SelectCompInst")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> SelectComp(int companyId, string staffId)
    {
        ...
    }
