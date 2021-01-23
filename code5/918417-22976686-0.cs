    List<Employee> allEmployees = new List<Employee>();
    private void buttonSave_Click(object sender, EventArgs e)
        {
            //read user input
            int empId = Int32.Parse(textBoxId.Text);
            string empFlName = textBoxFLName.Text;
            double empAnnual = double.Parse(textBoxAnnual.Text);
            
            // create new Employee object
            Employee emp = new Employee(empId, empFlName, empAnnual);
            
            // add new employee to container (for example array, list, etc). 
            // In this case I will prefer to use list, becouse it can grow dynamically
            allEmployees.Add(emp);
    
        }
