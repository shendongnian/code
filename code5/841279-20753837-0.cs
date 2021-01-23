    [HttpPost]
            public ActionResult Create(FormCollection formCollection)
            {
                if (ModelState.IsValid)
                {
                    foreach (string key in formCollection.AllKeys)
                    {
                        Response.Write("Key = " + key + "  ");
                        Response.Write("Value = " + formCollection[key]);
                        Response.Write("<br/>");
                    }
                }
            List<Department> departments = new List<Department>();
            departments = objDepartmentBusinessLayer.Department;
            SelectList departmentList = new SelectList(departments, "ID", "Name");
            ViewBag.Departments = departmentList;
                return View();
            }
