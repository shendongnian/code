    [HttpPost]
    [Route("Admin/Image/Delete")]
    public ActionResult Delete(int[] ids)
    {
       foreach(int i in ids)
          // delete
       return Content("successfully deleted " + ids.Length + " items.");
    }
