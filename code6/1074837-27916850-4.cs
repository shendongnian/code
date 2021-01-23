    public ActionResult Create()
    {
      ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
      ViewBag.ProcedureSubCategoryID = new SelectList(db.ProcedureSubCategories, "ID", "Name");
      return View();
    }
    @Html.DropDownList("ProcedureSubCategoryID", null, new { @class = "form-control" })
