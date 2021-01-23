    public object Get(Employee obj)
    {
        var objlist = new EmployeeResponse {listofemp = objEmploye.GetAll().ToList()};
        return objlist.listofemp;
    }
