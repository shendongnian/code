    [HttpGet, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        return View(new DeleteConfirmViewModel());
    }
