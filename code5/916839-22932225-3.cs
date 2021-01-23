    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id, DeleteConfirmViewModel viewModel)
    {
        if (ModelState.IsValid)
            return View(viewModel);
        card temp_card = db.cardss.Find(id);
        temp_card.deleted = true;
        temp_card.reason = viewModel.Reason;
        db.SaveChanges();
        return View(temp_card);
    }
