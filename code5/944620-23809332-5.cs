    public ActionResult Save(MyModel model, string action)
    {
        var commentsToAction = model.Comments.Where(x => x.Checked);
        if (action == "Approve") {
            foreach (var c in commentsToAction) {
                // approve c
            }
        } else if (action == "Delete") {
            foreach (var c in commentsToAction) {
                // delete c
            }
        }
    }
