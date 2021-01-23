    public ActionResult Delete(int id = 0)
        {
            Entry entry = _db.Entries.Single(r => r.Id == id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }
        //
        // POST: /Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var entryToDelete = _db.Entries.Single(r => r.Id == id);
            _db.Entries.Remove(entryToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index",new { id =  entryToDelete.CategoryId });
        }
