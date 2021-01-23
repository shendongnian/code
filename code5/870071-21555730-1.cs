    Employee employee;
    using (vitaeEntities db = new vitaeEntities())
    {
        int empId = ((Employee)dtgrid_Emp.SelectedItem).ID_EMployee;
        employee = db.Employee.Where(em => em.ID_EMployee == empId).Single();
    }
    detail wDetail = new detail(employee);
    wDetail.Show();
