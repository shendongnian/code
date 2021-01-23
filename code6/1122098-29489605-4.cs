     // GET: message/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                message message = db.messages.Find(id);
                if (message == null)
                {
                    return HttpNotFound();
                }
                return View(message);
            }
    
