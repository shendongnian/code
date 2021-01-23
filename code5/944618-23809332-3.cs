    public ActionResult Save(MyModel model)
    {
        var commentsToAction = model.Comments.Where(x => x.Checked);
        if (Request.Form["action"] == "Approve") {
            foreach (var c in commentsToAction) {
                // approve c
            }
        } else if (Request.Form["action"] == "Delete") {
            foreach (var c in commentsToAction) {
                // delete c
            }
        }
    }
