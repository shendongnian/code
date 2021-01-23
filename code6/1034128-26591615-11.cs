        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = deleteRepo.Read(id); //Here is the 2nd change (from ReadOneRepo.Read() to the inherited deleteRepo.Read()).
            deleteRepo.Delete(student);
            return RedirectToAction("Index");
        }
