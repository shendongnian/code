    public ActionResult DeleteLabel(int id)
            {
                Delete(id);
                dbPanAgroDMSContext.SaveChanges();
                return Json(new { Result = "OK" });
            }
    private void Delete(int id)
    {
          //For given id get all child ones first            
              var query = dbPanAgroDMSContext.LabelMaster.Where(x => x.ParentLabelId == id).ToList();
                foreach(var item in query)
                {
                         //for each child ,delet its' childs by calling recursively
                        Delete(item.Id);
                }
                LabelMaster label = dbPanAgroDMSContext.LabelMaster.Find(id);
                dbPanAgroDMSContext.LabelMaster.Remove(label);
    }
