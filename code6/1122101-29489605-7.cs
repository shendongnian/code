            // POST: message/Delete/5
            public ActionResult Delete(int? id)
            {
                if(id !=null){
                   message message = db.messages.Find(id);
                   db.messages.Remove(message);
                   db.SaveChanges();
                   return RedirectToAction("Index");
                }
                else
                {
                   return HttpNotFound();
                }
            }
