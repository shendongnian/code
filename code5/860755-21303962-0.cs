    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include="DeviceId,DeviceSerialNumber,DeviceUser,DeviceDictionaryId,Batch,Start,End")] Device device, string viewName)
    {
         if (ModelState.IsValid)
         {
              db.Entry(device).State = EntityState.Modified;
              db.SaveChanges();
              return RedirectToAction(viewName);
         }
         return View(device);
    }
