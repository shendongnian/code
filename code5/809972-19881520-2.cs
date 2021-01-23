    public ActionResult Sort(IEnumerable<string> something)
    {
      // iterates only checked items
      foreach(var item in something)
      {
        var correspondingDropdownValue = Request.Form[item]
      }
    }
