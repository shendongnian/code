    public ActionResult SearchIndex(string searchString, string tableName)
    {
        if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(tableName))
        {
            switch (tableName.ToLower())
            {
                case "number":
                    var numbers = from m in db.Numbers
                        where m.Number.Contains(searchString)
                        select m;
                    //View "Number" should use strongly typed IEnumerable<Number>
                    return View("Number", numbers);
                case "assignment":
                    var assignments = from m in db.Assignments
                        where m.AssignmentName.Contains(searchString)
                        select m;
                    //View "Assignment" should use strongly typed IEnumerable<Assignment>
                    return View("Assignment", assignments);
                //Add cases for other each tables
                case "mytable":
                    var mytables = from m in db.MyTables
                        where m.MyField.Contains(searchString)
                        select m;
                    //View "MyView" should use strongly typed IEnumerable<MyView>
                    return View("MyView", mytables);
                default:
                    return RedirectToAction("Index");
            }
        }
    
        return RedirectToAction("Index");
    }
