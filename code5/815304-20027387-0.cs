    public ActionResult GetEmployees()
    {
        var employeeList = new EmployeeListViewModel {
            Emp = new List<Employee>
            {
               new Employee {  EmpName= "ScottGu", EmpPhone = "23232323", EmpNum="242342"},
               new Employee { EmpName = "Scott Hanselman", EmpPhone = "3435353", EmpNum="34535"},
               new Employee { EmpName = "Jon Galloway", EmpPhone = "4534535345345",   
                  EmpNum="345353"}
    
            }
        };
    
        return Json(RenderPartialView("_EmpPartial", employeeList ));
    }
    protected string RenderPartialView(string partialViewName, object model = null)
            {
                if (ControllerContext == null)
                    return string.Empty;
    
                if (string.IsNullOrEmpty(partialViewName))
                    throw new ArgumentNullException("partialViewName");
    
                ModelState.Clear();//Remove possible model binding error.
    
                ViewData.Model = model;//Set the model to the partial view
    
                using (var sw = new StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, partialViewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    return sw.GetStringBuilder().ToString();
                }
            }
