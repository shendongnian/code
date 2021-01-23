    private void btn_Detail_Click(object sender, RoutedEventArgs e)
    {
        using (vitaeEntities db = new vitaeEntities())
        {
            int empId = ((Employee)dtgrid_Emp.SelectedItem).ID_EMployee;
            Employee query = db.Employee.Where(em => em.ID_EMployee == empId).Single();
            //set the call of your detail inside the using or set empId out of the using
            detail wDetail = new detail(empId);
            wDetail.Show();
        }            
       
    }
