    public ActionResult isNull(int? id, Func<int, ActionResult> _else) {
          if (id == null) {
            return RedirectToAction("Index");
          } else {
            return _else(id.value);
          }
    }
