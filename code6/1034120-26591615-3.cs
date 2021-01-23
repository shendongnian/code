        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = deleteRepo.Read(id); //Here is the change.
            deleteRepo.Delete(student);
            return RedirectToAction("Index");
        }
