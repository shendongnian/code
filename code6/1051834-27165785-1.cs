    public JsonResult AllPosition()
    {
        EmployeeService employeeService = new EmployeeService();
        List<Position> positions= employeeService.GetAllPosition();
       	return Json(positions, JsonRequestBehavior.AllowGet);
    }
